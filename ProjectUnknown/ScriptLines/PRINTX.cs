using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINTX : Models.ScriptLine
    {
        private string _text;
        private string _sleeptime;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] r = Helper.Split(line);
            this._sleeptime = r[0];
            this._text = r[1];
        }

        public override void Run(FConsole console)
        {
            string p = Expression.INSTANCE.ReplaceVF(this._text, this.ScriptFile);
            int sleep = (int)(Convert.ToDouble(Expression.INSTANCE.RandR(this._sleeptime, this.ScriptFile)) * 1000);

            foreach (var i in p)
            {
                console.Write(i.ToString());
                Thread.Sleep(sleep);
            }
        }
    }
}
