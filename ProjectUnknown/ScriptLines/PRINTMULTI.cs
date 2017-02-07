using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINTMULTI : Models.ScriptLine
    {
        private List<string> _text;

        public PRINTMULTI()
        {
            this._text = new List<string>();
        }

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            while (true)
            {
                string i = script.GetLine(++e, false);
                if (Helper.Trim(i) == "ENDPRINTMULTI") break;
                _text.Add(i);

                if (e > script.Line) throw new Exceptions.ParserException(line, this.Line, script); 
            }
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            foreach(string i in _text)
            {
                console.WriteLine(i);
            }
        }
    }
}
