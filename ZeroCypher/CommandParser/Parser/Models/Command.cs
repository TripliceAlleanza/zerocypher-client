using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser.Parser.Models {
    public class Command {
        public string Name { get; set; }
        public string description { get; set; }
        public List<Command> ExplicitArguments { get; set; }
        public Command() {
            ExplicitArguments = new List<Command>();
        }

        public Command(string name, string description) {
            Name = name;
            this.description = description;
            ExplicitArguments = new List<Command>();
        }

        public Command(string name, string description, List<Command> explicitArguments) {
            Name = name;
            this.description = description;
            ExplicitArguments = explicitArguments;
            ExplicitArguments = new List<Command>();
        }

    }
}
