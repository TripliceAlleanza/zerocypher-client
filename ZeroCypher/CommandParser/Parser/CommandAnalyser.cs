using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandParser.Interface;
using CommandParser.Parser.Models;
using CommandParser.Parser.CommandSyntax;
using System.Reflection;
namespace CommandParser.Parser {
    //[AttributeUsage(AttributeTargets.All)]
    public class CommandAnalyser : System.Attribute {
        public Delegates.ConsoleWrite Write;
        public Delegates.SerialOpenConnection OpenConnection;
        public Delegates.SerialCloseConnection CloseConnection;
        public Delegates.SerialSendData SendData;
        public Delegates.SerialInfo Serialinfo;
        //public bool TESTING = false;
        private Syntax BuiltInCommands = new Syntax();

        public void Execute(string command) {
            bool InformationComm = false;
            if (command[command.Length - 1] == '?') {
                command = command.Remove(command.Length - 1, 1);
                InformationComm = true;
            }
            
            string[] values = command.Split(' ');

            if (BuiltInCommands.SearchCommand(values[0])) {
                if (InformationComm) {
                    Information(values);
                }
                else {
                    MethodInfo CommandRoutine = typeof(CommandAnalyser).GetMethod(values[0], BindingFlags.NonPublic | BindingFlags.Instance);
                    CommandRoutine.Invoke(this, new object[] { values });
                }
            }
            else {
                WriteInvalidCommand();
            }
        }

        private void Help(string[] comm) {
            if (comm.GetUpperBound(0) > 0) {
                WriteInvalidArgument();
            }
            else
                Write(BuiltInCommands.AllCommandsDescription());
        }

        private void SerialOpen(string[] comm) {
            try {
                if (comm.Length < 5) {
                    WriteInvalidArgument();
                }
                else {
                    string N = "";
                    string B = "";
                    int AllDone = 0;
                    for (int i = 0; i < comm.Length; i++) {
                        if (comm[i] == "-N") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-B") {
                                    N += comm[j];
                                    if (j == comm.GetUpperBound(0)) {
                                        AllDone++;
                                        break;
                                    }
                                }
                                else {
                                    AllDone++;
                                    i = j;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-B") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-N") {
                                    B += comm[j];
                                    if(j == comm.GetUpperBound(0)) {
                                        AllDone++;
                                        break;
                                    }
                                }
                                else {
                                    AllDone++;
                                    i = j;
                                    break;
                                }
                            }
                        }
                        if (AllDone == 2)
                            break;
                    }
                    if (AllDone == 2)
                        OpenConnection(N, Convert.ToInt32(B));
                    else
                        WriteInvalidArgument();
                }
            }
            catch (Exception ex) {
                Write(ex.Message + "\n");
                WriteInvalidArgument();
            }
        }
        private void Information(string[] comm) {
            Write(BuiltInCommands.CommandDescriptionWithArguments(comm[0]));
        }
        private void SerialClose(string[] comm) {
            if (comm.Length == 1)
                CloseConnection();
            else
                WriteInvalidArgument();
        }
        private void SerialInfo(string[] comm) {
            Serialinfo();
        }
        private void Encode(string[] comm) {
            Send(comm, true);
        }
        private void Decode(string[] comm) {
            Send(comm, false);
        }
        private void Send(string[]comm, bool MODE) {

            try {
                if (comm.Length < 7) {
                    WriteInvalidArgument();
                }
                else {
                    List<string> com = comm.ToList();
                    int first = com.FindIndex(x => x.Contains("\""));
                    int second = com.FindLastIndex(x => x.Contains("\""));
                    if(first == second) {
                        com[first] = com[first].Replace("\"","");
                        comm = com.ToArray();
                    }
                    else {
                        List<string> temp = new List<string>();
                        com[first] = com[first].Replace("\"", "");
                        com[second] = com[second].Replace("\"", "");
                        for (int i = 0; i < com.Count; i++) {
                            if(i == first) {
                                temp.Add(com[i]);
                                if (first + 1 == second)
                                    temp.Add(" ");
                                for (int j = i+1; j < com.Count; j++) {
                                    if(j != second) {
                                        temp.Add(" ");
                                        temp.Add(com[j]);
                                    }
                                    else {
                                        i = j;
                                        temp.Add(" ");
                                        break;
                                    }
                                }
                            }
                            temp.Add(com[i]);
                        }
                        comm = temp.ToArray();
                    }
                    string M = "";
                    string K = "";
                    string T = "";
                    int AllDone = 0;
                    for (int i = 0; i < comm.Length; i++) {
                        if (comm[i] == "-M") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-K" && comm[j] != "-T") {
                                    M += comm[j];
                                    if (j == comm.GetUpperBound(0)) {
                                        AllDone++;
                                        break;
                                    }
                                }
                                else {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-K") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-M" && comm[j] != "-T") {
                                    K += comm[j];
                                    if (j == comm.GetUpperBound(0)) {
                                        AllDone++;
                                        break;
                                    }
                                }
                                else {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-T") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-M" && comm[j] != "-K") {
                                    T += comm[j];
                                    if (j == comm.GetUpperBound(0)) {
                                        AllDone++;
                                        break;
                                    }
                                }
                                else {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (AllDone == 3)
                            break;
                    }
                    if (AllDone == 3)
                        try {
                            SendData(M, Convert.ToInt32(K), T, MODE);
                        }
                        catch (InvalidCastException) {
                            Write("THE KEY ARGUMENT MUST BE NUMERIC");
                        }
                    else
                        WriteInvalidArgument();
                }
            }
            catch (Exception ex) {
                Write(ex.Message + "\n");
                WriteInvalidArgument();
            }
        }

        private void WriteInvalidArgument() {
            Write("Invalid Arguments\n");
        }
        private void WriteInvalidCommand() {
            Write("Invalid Command\n");
        }
        
    }
}
