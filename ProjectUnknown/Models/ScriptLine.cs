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
        private int _line = -1;


        public virtual void Run(FConsole console)
        {

        }

        public virtual void Process(string line, ref int e, ScriptFile script)
        {
            this._line = e;
            this._script = script;
        }   
    }
}
