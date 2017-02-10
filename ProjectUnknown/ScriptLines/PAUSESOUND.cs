using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PAUSESOUND : PLAYSOUND
    {
        public override void Run(FConsole console)
        {
            SoundManager.INSTANCE.PausePlay(this._filename);
        }
    }
}
