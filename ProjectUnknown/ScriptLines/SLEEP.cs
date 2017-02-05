using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SLEEP : Models.ScriptLine
    {
        private int _sleeptime;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            try
            {
                _sleeptime = (int)(Convert.ToDouble(line) * 1000.0);
            }
            catch(FormatException)
            {
                throw new Exceptions.ParserException(line, e);
            }
            
        }
        
        public override void Run(FConsole console)
        {
            base.Run(console);
            Thread.Sleep(_sleeptime);
        }
    }
}
