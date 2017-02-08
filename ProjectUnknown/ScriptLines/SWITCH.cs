using ProjectFork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SWITCH : Models.ScriptLine
    {
        private Dictionary<string, List<ScriptLine>> _switches;
        private List<ScriptLine> _default;
        private string _deter;

        public SWITCH()
        {
            this._switches = new Dictionary<string, List<ScriptLine>>();
            this._default = null;
        }

        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            List<ScriptLine> nowcase  = null;
            this._deter = line;
            while (true)
            {
                string i = this.ScriptFile.GetLine(++e);
                if(i.Length > 5 && i.Substring(0, 5).ToUpper() == "CASE ")
                {
                    string[] r = Helper.Split(i);
                    nowcase = this.CreateCase(r[1]);
                    continue;
                }

                if (i.ToUpper() == "DEFAULT")
                {
                    this._default = new List<ScriptLine>();
                    nowcase = this._default;
                    continue;
                }

                if (i.ToUpper() == "ENDSWITCH") break;

                if(nowcase != null)
                {
                    nowcase.Add(Helper.CreateScriptLine(i, ref e, script, this));
                }
                else
                {
                    throw new Exceptions.ParserException(i, e, script);
                }

            }
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string c = Expression.INSTANCE.RandR(this._deter, this.ScriptFile);
            if (this._switches.ContainsKey(c))
            {
                Scripter.INSTANCE.RunScript(this._switches[c], this, console);
            }
            else if(this._default != null)
            {
                Scripter.INSTANCE.RunScript(this._default, this, console);
            }
            else
            {
                throw new Exceptions.RuntimeException("Case " + c + " not found.");
            }
        }


        private List<ScriptLine> CreateCase(string _case)
        {
            List<ScriptLine> r = new List<ScriptLine>();
            this._switches.Add(_case, r);
            return r;
        }
    }
}
