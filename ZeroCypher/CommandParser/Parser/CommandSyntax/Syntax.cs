using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandParser.Parser.Models;
using Newtonsoft.Json;
using System.IO;

namespace CommandParser.Parser.CommandSyntax {
    public class Syntax {
        private List<Command> _commands;
        public Syntax() {
            BuildCommands();
        }
        private void BuildCommands() {
            _commands = JsonConvert.DeserializeObject<List<Command>>(Resources.InternalBuiltInCommands.ToString());
        }
        public bool SearchCommand(string name) {
            if (_commands.Find(x => x.Name == name) != null)
                return true; //Command Found
            else
                return false; //Command NOT Found
        }
        public bool SearchCommandArg(string CommandName, string ArgumentName) {
            int comIndex = _commands.FindIndex(x => x.Name == CommandName);
            if (comIndex == -1)
                return false;   //Command NOT Found
            if (_commands[comIndex].ExplicitArguments.Find(x => x.Name == ArgumentName) != null)
                return true;    //Argument Found
            else
                return false;   //Argument NOT Found
        }
    }
}
