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
        private string _sleeptime;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            try
            {
                _sleeptime = line;
            }
            catch(FormatException)
            {
                throw new Exceptions.ParserException(line, e, script);
            }
            
        }
        
        public override void Run(FConsole console)
        {
            base.Run(console);
            string result = Expression.INSTANCE.RandR(this._sleeptime, this.ScriptFile);
            try
            {
                int time = (int)(Convert.ToDouble(result) * 1000);
                Thread.Sleep(time);
            }
            catch
            {
                throw new Exceptions.RuntimeException("Can't parse: " + result);
            }

        }
    }
}
