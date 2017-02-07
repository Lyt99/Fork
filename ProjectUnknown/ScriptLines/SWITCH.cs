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

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
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
                    nowcase.Add(Helper.CreateScriptLine(i, ref e, script));
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
                this.RunList(this._switches[c], console);
            }
            else if(this._default != null)
            {
                this.RunList(this._default, console);
            }
            else
            {
                throw new Exceptions.RuntimeException("Case " + c + " not found.");
            }
        }

        private void RunList(List<ScriptLine> list, FConsole console)
        {
            foreach(var i in list)
            {
                if (this.ScriptFile.Terminated || this.ScriptFile.Status != 0) break;
                i.Run(console);
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
