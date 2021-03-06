﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SET : Models.ScriptLine
    {
        private string _key;
        private string _value;
        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            string[] r = Helper.Split(line);
            this._key = r[0];
            if (String.IsNullOrEmpty(this._key)) throw new Exceptions.ParserException(line, e, this.ScriptFile);
            this._value = r[1];

        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string k = Expression.INSTANCE.ReplaceVF(this._key, this.ScriptFile);
            string s = Expression.INSTANCE.RandR(this._value, this.ScriptFile);
            this.Set(k, s);
        }

        protected virtual void Set(string k, string s)
        {
            this.ScriptFile.SetLocalVars(k, s);
        }
    }
}
 