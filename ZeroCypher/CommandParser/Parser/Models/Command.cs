namespace CommandParser.Parser.Models {
    using System.Collections.Generic;

    public class Command {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Command> ExplicitArguments { get; set; }
        public Command() {
            ExplicitArguments = new List<Command>();
        }

        public Command(string name, string description) {
            Name = name;
            Description = description;
            ExplicitArguments = new List<Command>();
        }

        public Command(string name, string description, List<Command> explicitArguments) {
            Name = name;
            Description = description;
            ExplicitArguments = explicitArguments;
            ExplicitArguments = new List<Command>();
        }

    }
}
