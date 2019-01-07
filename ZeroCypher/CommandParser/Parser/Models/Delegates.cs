
namespace CommandParser.Parser.Models {
    public class Delegates {
        public delegate void ConsoleWrite(string Output);
        public delegate void SerialOpenConnection(string PortName, int BaudeRate);
        public delegate void SerialCloseConnection();
        public delegate void SerialSendData();
        public delegate void SerialInfo();
    }
}
