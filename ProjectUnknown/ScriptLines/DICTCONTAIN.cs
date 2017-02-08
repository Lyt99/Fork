using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class DICTCONTAIN : Models.ScriptLine
    {

        private string _flag;
        public string _key;

        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            string[] r = Helper.Split(line);
            this._flag = r[0];
            this._key = r[1];
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string f = Expression.INSTANCE.ReplaceVF(this._flag, this.ScriptFile);
            string k = Expression.INSTANCE.ReplaceVF(this._key, this.ScriptFile);
            if (Test(k))
            {
                DataManager.INSTANCE.SetFlag(f, true);
            }
            else
            {
                DataManager.INSTANCE.SetFlag(f, false);
            }
        }

        public virtual bool Test(string k)
        {
            return (DataManager.INSTANCE.GetDictDictionary().ContainsKey(k));
        }
    }
}
