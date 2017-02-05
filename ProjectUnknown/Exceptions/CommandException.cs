using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.Exceptions
{
    class CommandException : ApplicationException
    {
        public CommandException(string message) : base(message) { }
    }
}
