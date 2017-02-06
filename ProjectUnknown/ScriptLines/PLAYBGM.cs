using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PLAYBGM : Models.ScriptLine
    {
        private string _name;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._name = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string s = Expression.INSTANCE.ReplaceVF(this._name, this.ScriptFile);
            SoundManager.INSTANCE.PlayBGM(s);
        }
    }
}
