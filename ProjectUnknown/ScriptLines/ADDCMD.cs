using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class ADDCMD : Models.ScriptLine
    {
        private string _scriptfile;
        private string _cmd;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] r = Helper.Split(line);

            if (r[1] == "") throw new Exceptions.ParserException(line, e, script);
            this._scriptfile = r[0];
            this._cmd = r[1];
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            Commander.INSTANCE.AddCommand(this._cmd, this._scriptfile);
        }
    }
}
