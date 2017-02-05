using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class LISTDEL : Models.ScriptLine
    {
        private string _key;
        private string _value;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] r = Helper.Split(line);

            this._key = r[0];
            this._value = r[1];
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            DataManager.INSTANCE.DelFromList(this._key, this._value);
        }
    }
}
