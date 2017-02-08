using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFork.Models;

namespace ProjectFork.ScriptLines
{
    class WHILE : Models.ScriptLine
    {
        private string _con;
        private List<Models.ScriptLine> _body;

        public WHILE()
        {
            this._body = new List<Models.ScriptLine>();
        }

        public override void Process(string line, ref int e, ScriptFile script, ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            this._con = line;

            while (true)
            {
                string s = this.ScriptFile.GetLine(++e);
                if (s == "ENDWHILE") break;
                this._body.Add(Helper.CreateScriptLine(s, ref e, this.ScriptFile, belong));
            }
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            while (true)
            {
                string d = Expression.INSTANCE.RandR(this._con, this.ScriptFile);
                if (d == "True") Scripter.INSTANCE.RunScript(this._body, this, console);
                else if (d == "False") break;
                else throw new Exceptions.RuntimeException(d + " is not a Boolean value.");          
            }
        }
    }
}
