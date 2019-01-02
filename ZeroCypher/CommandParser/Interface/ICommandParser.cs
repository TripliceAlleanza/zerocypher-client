using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser.Interface {
    public interface ICommandParser {
        string Execute(Delegate textbox, Delegate serialport);
        string MoreInformation(Delegate textbox);
    }
}
