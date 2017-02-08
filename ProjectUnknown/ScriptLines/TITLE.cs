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
        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
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
