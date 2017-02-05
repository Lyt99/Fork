using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.Exceptions
{
    class ScriptNotFoundException : ApplicationException
    {
        public ScriptNotFoundException(string name) : base("File/Folder: " + name + " not found.") { }
    }
}
