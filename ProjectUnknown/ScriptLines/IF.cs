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
        private List<ScriptLine> _true;
        private List<ScriptLine> _false;
        private string _condition;

        public IF()
        {
            this._true = new List<ScriptLine>();
            this._false = new List<ScriptLine>();
        }

        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            this._condition = line;
            base.Process(line, ref e, script, belong);

            List<ScriptLine> now = this._true;
            while (true)
            {
                string i = script.GetLine(++e);
                if (i.ToUpper() == "ELSE")
                {
                    now = this._false;
                    continue;
                }
                if(i.ToUpper() == "ENDIF")
                {
                    break;
                }

                now.Add(Helper.CreateScriptLine(i, ref e, script, this));
                
            }

        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string result = Expression.INSTANCE.RandR(this._condition, this.ScriptFile);
            if (result == "True")
                Scripter.INSTANCE.RunScript(this._true, this, console);
            else if (result == "False")
                Scripter.INSTANCE.RunScript(this._false, this, console);
            else throw new Exceptions.RuntimeException(result + " is not a Boolean value");
        }

    }
}
