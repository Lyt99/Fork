using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PLAYSOUND : Models.ScriptLine
    {
        private string _filename;
        public override void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            base.Process(line, ref e, script, belong);
            this._filename = line;
        }

        public override void Run(FConsole console)
        {
            string s = Expression.INSTANCE.ReplaceVF(this._filename, this.ScriptFile);
            SoundManager.INSTANCE.PlaySoundSync(s);
        }
    }
}
