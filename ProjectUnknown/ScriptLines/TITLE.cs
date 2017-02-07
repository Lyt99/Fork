using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class TITLE : Models.ScriptLine
    {
        public string _title;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._title = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string t = Expression.INSTANCE.ReplaceVF(this._title, this.ScriptFile);
            console.setTitle(t);
        }
    }
}
