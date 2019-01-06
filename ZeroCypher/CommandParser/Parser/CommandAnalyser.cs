using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandParser.Interface;
using System.Reflection;
using CommandParser.Parser.Models;
using CommandParser.Parser.CommandSyntax;

namespace CommandParser.Parser {
    //[AttributeUsage(AttributeTargets.All)]
    public class CommandAnalyser : System.Attribute {
        public Delegates.ConsoleWrite Write;
        public Delegates.SerialOpenConnection OpenConnection;
        public Delegates.SerialCloseConnection CloseConnection;
        public Delegates.SerialSendData SendData;
        public bool TESTING = false;
        private Syntax BuiltInCommands = new Syntax();

        public CommandAnalyser() {
            
        }

        public void Execute(string command) {
            string[] values = command.Split(' ');

            if (BuiltInCommands.SearchCommand(values[0])) {
                MethodInfo CommandRoutine = typeof(CommandAnalyser).GetMethod(values[0], BindingFlags.NonPublic | BindingFlags.Instance);
                CommandRoutine.Invoke(this,new object[] { values});
            }
            else {
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

        private void Help(string[] comm) {
            if (comm.GetUpperBound(0) > 0) {
                WriteInvalidArgument();
            }
            else
                Write(BuiltInCommands.AllCommandsDescription());
        }

        public string MoreInformation(Delegate textbox) {
            throw new NotImplementedException();
        }
        private void SerialOpen() {

        }
        private void WriteInvalidArgument() {
            Write("Invalid Argument\n");
        }
        private void WriteInvalidCommand() {
            Write("Invalid Argument\n");
        }
    }
}
