using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class RESUMEBGM : STOPBGM
    {
        public override void Run(FConsole console)
        {
            SoundManager.INSTANCE.ResumeBGM();
        }
    }
}
