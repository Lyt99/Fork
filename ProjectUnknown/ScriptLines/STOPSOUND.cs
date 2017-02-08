using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class STOPSOUND : Models.ScriptLine
    {
        public string _name;
        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            this._name = line;
            base.Process(line, ref e, script, belong);

        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string s = Expression.INSTANCE.ReplaceVF(this._name, this.ScriptFile);
            SoundManager.INSTANCE.StopPlay(s);
        }
    }
}
