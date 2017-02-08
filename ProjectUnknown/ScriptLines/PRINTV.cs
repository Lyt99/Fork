using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINTV : Models.ScriptLine
    {
        private string _text;

        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            this._text = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string p = Expression.INSTANCE.ReplaceVF(this._text, this.ScriptFile);
            console.Write(p);
        }
    }
}
