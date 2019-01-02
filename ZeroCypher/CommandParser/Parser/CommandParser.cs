using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandParser.Interface;
using CommandParser.Parser.Models;

namespace CommandParser.Parser {
    public class CommandParser {
        public Delegates.ConsoleWrite Write;
        public Delegates.SerialOpenConnection OpenConnection;
        public Delegates.SerialCloseConnection CloseConnection;
        public Delegates.SerialSendData SendData;
        public void Execute(string command) {
            string[] values = command.Split(' ');
            switch (values[0]) {
                case "SerialOpen":
                    
                    break;
                case "SerialClose":
                    break;
                case "SerialInfo":
                    break;
                default:
                    Write($"'{values[0]}' is an invalid command");
                    break;
            }
        }

        public string MoreInformation(Delegate textbox) {
            throw new NotImplementedException();
        }
        private void SerialOpen() {

        }
    }
}
