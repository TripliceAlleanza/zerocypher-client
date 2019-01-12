﻿using System;
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
        public Delegates.SerialInfo Serialinfo;
        //public bool TESTING = false;
        private Syntax BuiltInCommands = new Syntax();

        public CommandAnalyser() {

        }

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
                                if (comm[j] != "-B")
                                    N += comm[j];
                                else {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-B") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-N")
                                    B += comm[j];
                                else {
                                    AllDone++;
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
                    string M = "";
                    string K = "";
                    string T = "";
                    int AllDone = 0;
                    for (int i = 0; i < comm.Length; i++) {
                        if (comm[i] == "-M") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-K" || comm[j] != "-T")
                                    M += comm[j];
                                else {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-K") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-M" || comm[j] != "-T")
                                    K += comm[j];
                                else {
                                    AllDone++;
                                    break;
                                }
                            }
                        }
                        if (comm[i] == "-T") {
                            for (int j = i + 1; j < comm.Length; j++) {
                                if (comm[j] != "-M" || comm[j] != "-K")
                                    T += comm[j];
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
