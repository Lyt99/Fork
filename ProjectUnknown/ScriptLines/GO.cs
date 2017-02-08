using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFork.Models;

namespace ProjectFork.ScriptLines
{
    class GO : Models.ScriptLine
    {
        private string _script;
        public override void Process(string line, ref int e, ScriptFile script, ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            this._script = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string n = Expression.INSTANCE.ReplaceVF(this._script, this.ScriptFile);
            ScriptFile sf = Scripter.INSTANCE.GetScriptFile(n).GetCopy();

            Task.Run(() =>
            {
                sf.Run(console);
            });

        }
    }
}
