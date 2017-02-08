using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class QUIT : Models.ScriptLine
    {
        public override void Run(FConsole console)
        {
            base.Run(console);
            Environment.Exit(0);
        }
    }
}
