using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINT : Models.ScriptLine
    {

        private string _text = "";

        public override void Run(FConsole console)
        {
            base.Run(console);
            console.Write(this._text);
        }

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._text = line;
        }
    }
}
