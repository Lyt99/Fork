using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class LISTCONTAIN : Models.ScriptLine
    {
        private string _flagname;
        private string _key;
        private string _value;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);

            string[] r = line.Split(' ');
            if (r.Length != 3) throw new Exceptions.ParserException(line, e);

            this._flagname = r[0];
            this._key = r[1];
            this._value = r[2];
        }

        public override void Run(FConsole console)
        {
            string k = Expression.INSTANCE.ReplaceVF(this._key, this.ScriptFile);
            string l = Expression.INSTANCE.RandR(this._value, this.ScriptFile);
            string f = Expression.INSTANCE.ReplaceVF(this._flagname, this.ScriptFile);
            base.Run(console);
            if (DataManager.INSTANCE.GetList(k).Contains(l))
                DataManager.INSTANCE.SetFlag(f, true);
            else
                DataManager.INSTANCE.SetFlag(f, false);
        }
    }
}
