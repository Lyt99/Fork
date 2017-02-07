﻿using System;
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
            if(String.IsNullOrEmpty(this._loadname))
                SaveManager.INSTANCE.DoLoad();
            else
            {
                string s = Expression.INSTANCE.ReplaceVF(this._loadname, this.ScriptFile);
                SaveManager.INSTANCE.Save(s + ".sav");
            }
        }
    }
}
