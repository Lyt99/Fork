using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.Models
{
    class ScriptLine
    {
        public int Line
        {
            get
            {
                return this._line;
            }
        }

        public ScriptFile ScriptFile
        {
            get
            {
                return this._script;
            }
        }

        private ScriptFile _script;
        private ScriptLine _belong;
        private int _line = -1;
        private int _status = 0;

        public virtual void Run(FConsole console)
        {
            this._status = 0;
        }

        public virtual void Process(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            this._line = e;
            this._script = script;
            this._belong = belong;
        }   

        public ScriptLine GetBelong()
        {
            return this._belong;
        }

        public int GetStatus()
        {
            return this._status;
        }

        public void SetStatus(int status, ScriptLine curr)
        {
            if (curr is ScriptLines.WHILE || curr is ScriptLines.FOR) return;
            this._status = status;
        }
    }
}
