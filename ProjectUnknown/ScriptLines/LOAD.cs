using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class LOAD : Models.ScriptLine
    {

        private string _loadname;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._loadname = line;
        }
        public override void Run(FConsole console)
        {
            base.Run(console);
            bool r = true;
            if(String.IsNullOrEmpty(this._loadname))
                r = SaveManager.INSTANCE.DoLoad();
            else
            {
                string s = Expression.INSTANCE.ReplaceVF(this._loadname, this.ScriptFile);
                r = SaveManager.INSTANCE.Load(s + ".sav");
            }

            DataManager.INSTANCE.SetFlag("SAVE_SUCCESS", r);
        }
    }
}
