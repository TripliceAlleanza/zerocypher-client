using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandParser.Interface;
using System.Reflection;
using CommandParser.Parser.Models;
using CommandParser.Parser.CommandSyntax;

namespace CommandParser.Parser
{
    //[AttributeUsage(AttributeTargets.All)]
    public class CommandAnalyser:System.Attribute
    {
        public Delegates.ConsoleWrite Write;
        public Delegates.SerialOpenConnection OpenConnection;
        public Delegates.SerialCloseConnection CloseConnection;
        public Delegates.SerialSendData SendData;
        public Delegates.SerialInfo Serialinfo;
        public bool TESTING = false;
        private Syntax BuiltInCommands = new Syntax();

        public CommandAnalyser()
        {

        }

        public void Execute(string command)
        {
            string[] values = command.Split(' ');

            if (BuiltInCommands.SearchCommand(values[0]))
            {
                MethodInfo CommandRoutine = typeof(CommandAnalyser).GetMethod(values[0],BindingFlags.NonPublic | BindingFlags.Instance);
                CommandRoutine.Invoke(this,new object[] { values });
            } else
            {
                WriteInvalidCommand();
            }



            #region TODO_DELETE_IT
            //switch (values[0]) {
            //    case "SerialOpen":

            //        break;
            //    case "SerialClose":
            //        break;
            //    case "SerialInfo":
            //        break;
            //    case "?":
            //    case "Help":
            //        Help();
            //        break;
            //    default:
            //        Write($"'{values[0]}' is an invalid command");
            //        break;
            //}
            #endregion
        }

        private void Help(string[] comm)
        {
            if (comm.GetUpperBound(0) > 0)
            {
                WriteInvalidArgument();
            } else
                Write(BuiltInCommands.AllCommandsDescription());
        }

        public string MoreInformation(string[] comm)
        {
            throw new NotImplementedException();
        }
        private void SerialOpen(string[] comm)
        {
            try
            {
                if (comm.Length < 5)
                {
                    WriteInvalidArgument();
                } else
                {
                    string N = "";
                    string B = "";
                    int AllDone = 0;
                    for (int i = 0;i < comm.Length;i++)
                    {
                        if (comm[i] == "-N")
                        {
                            for (int j = i + 1;j < comm.Length;j++)
                            {
                                if (comm[j] != "-B")
                                    N += comm[j];
                                else
                                {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-B")
                        {
                            for (int j = i + 1;j < comm.Length;j++)
                            {
                                if (comm[j] != "-N")
                                    B += comm[j];
                                else
                                {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (AllDone == 2)
                            break;
                    }
                    OpenConnection(N,Convert.ToInt32(B));
                    
                }
            } catch (Exception ex)
            {
                Write(ex.Message+"\n");
                WriteInvalidArgument();
            }
        }
        private void SerialInfo(string[] comm)
        {
            Serialinfo();
        }
        private void WriteInvalidArgument()
        {
            Write("Invalid Arguments\n");
        }
        private void WriteInvalidCommand()
        {
            Write("Invalid Command\n");
        }
    }
}
