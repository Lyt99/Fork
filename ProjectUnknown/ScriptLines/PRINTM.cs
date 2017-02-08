using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINTM : Models.ScriptLine
    {
        private List<string> _text;

        public PRINTM()
        {
            this._text = new List<string>();
        }

        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            while (true)
            {
                string i = script.GetLine(++e, false);
                if (Helper.Trim(i) == "ENDPRINTM") break;
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
