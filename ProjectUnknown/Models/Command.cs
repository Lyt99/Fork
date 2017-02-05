using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.Models
{
    class Command
    {
        public string cmd;
        public string script;
        public SortedDictionary<int, string> pars = new SortedDictionary<int, string>();
    }
}
