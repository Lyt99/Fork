using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINTFMT : Models.ScriptLine
    {
        private string _text;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._text = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string u = Expression.INSTANCE.UnescapeCodes(this._text);
            console.Write(u);
        }
    }
}
