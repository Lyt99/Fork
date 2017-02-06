using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SETVAR : Models.ScriptLine
    {
        private string _key;
        private string _value;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            var r = Helper.Split(line);
            if (String.IsNullOrEmpty(r[0]) || String.IsNullOrEmpty(r[1])) throw new Exceptions.ParserException(line, e);
            this._key = r[0];
            this._value = r[1];
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string r = Expression.INSTANCE.RandR(this._value, this.ScriptFile);
            DataManager.INSTANCE.SetVars(this._key, r);
        }
    }
}
