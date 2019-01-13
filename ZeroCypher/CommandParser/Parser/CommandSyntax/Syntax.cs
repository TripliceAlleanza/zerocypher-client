namespace CommandParser.Parser.CommandSyntax {
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Models;
    using Newtonsoft.Json;

    public class Syntax {
        private List<Command> _commands;
        public Syntax() {
            BuildCommands();
        }
        private void BuildCommands() {
            byte[] bytestream = Resources.InternalBuiltInCommands;
            string Jsonfile;
            using (StreamReader stream = new StreamReader(new MemoryStream(bytestream))) {
                Jsonfile = stream.ReadToEnd();
            }
            _commands = JsonConvert.DeserializeObject<List<Command>>(Jsonfile);
        }
        public bool SearchCommand(string name)
        {
            if (_commands.Find(x => x.Name == name) != null)
                return true; //Command Found
            return false; //Command NOT Found
        }
        public bool SearchCommandArg(string CommandName, string ArgumentName) {
            int comIndex = _commands.FindIndex(x => x.Name == CommandName);
            if (comIndex == -1)
                return false;   //Command NOT Found
            if (_commands[comIndex].ExplicitArguments.Find(x => x.Name == ArgumentName) != null)
                return true;    //Argument Found
            return false;   //Argument NOT Found
        }
        public string CommandDescription(string name) {
            Command com = _commands.Find(x => x.Name == name);
            if (com == null)
                return $"{name} is an invalid command";
            return $"{name}: {com.Description}";
        }
        public string CommandDescriptionWithArguments(string name) {
            Command com = _commands.Find(x => x.Name == name);
            if (com == null)
                return $"{name} is an invalid command";
            StringBuilder result = new StringBuilder(40);
            result.Append($"{name}: {com.Description}\nARGUMENTS:\n");

            if (com.ExplicitArguments.Count > 0) {
                foreach (var arg in com.ExplicitArguments) {
                    result.Append($"{arg.Name}: {arg.Description}\n");
                }
                return result.ToString();
            }

            return result + $"{name}: has no arguments\n";
        }
        public string AllCommandsDescription() {
            StringBuilder result = new StringBuilder(40);
            foreach (var comm in _commands) {
                result.Append($"{comm.Name}: {comm.Description}\n");
            }
            return result.ToString();
        }
    }
}
