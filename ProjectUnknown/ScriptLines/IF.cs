using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFork.Models;
namespace ProjectFork.ScriptLines
{
    class IF : Models.ScriptLine
    {
        private List<ScriptLine> _if;
        private List<ScriptLine> _else;
        private FConsole _console;
        private string _condition;

        public IF()
        {
            this._if = new List<ScriptLine>();
            this._else = new List<ScriptLine>();
        }

        public override void Process(string line, ref int e, ScriptFile script)
        {
            this._condition = line;
            base.Process(line, ref e, script);

            List<ScriptLine> now = this._if;
            while (true)
            {
                string i = script.GetLine(++e);
                if (i.ToUpper() == "ELSE")
                {
                    now = this._else;
                    continue;
                }
                if(i.ToUpper() == "ENDIF")
                {
                    break;
                }

                now.Add(Helper.CreateScriptLine(i, ref e, script));
                
            }

        }

        public override void Run(FConsole console)
        {
            this._console = console;
            base.Run(console);
            string result = Expression.INSTANCE.RandR(this._condition, this.ScriptFile);
            if (result == "True")
                this.RunBranch(this._if);
            else if (result == "False")
                this.RunBranch(this._else);
            else throw new Exceptions.RuntimeException(result + " is not a Boolean value");
        }

        private void RunBranch(List<ScriptLine> script)
        {
            foreach(ScriptLine i in script)
            {
                if (this.ScriptFile.Terminated || this.ScriptFile.Status != 0) break;
                i.Run(this._console);
            }
        }
    }
}
