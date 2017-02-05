using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class INPUT : Models.ScriptLine
    {
        private string _varname;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            this._varname = line;
            base.Process(line, ref e, script);
        }

        public override void Run(FConsole console)
        {
            string str = console.ReadLine();
            if (!String.IsNullOrEmpty(this._varname))
                this.ScriptFile.SetLocalVars(this._varname, str);
            base.Run(console);
        }
    }
}
