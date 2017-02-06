using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SETFLAG : Models.ScriptLine
    {
        private string _exp;
        private string _key;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] r = line.Split(' ');

            if (r.Length != 2) throw new Exceptions.ParserException(line, e);
            this._key = r[0];
            this._exp = r[1];
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string k = Expression.INSTANCE.ReplaceVF(this._key, this.ScriptFile);
            string s = Expression.INSTANCE.RandR(this._exp, this.ScriptFile);
            if(s == "True")
            {
                DataManager.INSTANCE.SetFlag(k, true);
            }
            else if(s == "False")
            {
                DataManager.INSTANCE.SetFlag(k, false);
            }
            else
            {
                throw new Exceptions.RuntimeException(s + " is not a Boolean value.");
            }
        }
    }
}
