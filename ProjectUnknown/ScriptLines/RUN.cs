using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class RUN : Models.ScriptLine
    {
        private string _script;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._script = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string s = Expression.INSTANCE.ReplaceVF(this._script, this.ScriptFile);
            Scripter.INSTANCE.RunScript(s);
        }
    }
}
