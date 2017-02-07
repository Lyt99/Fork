using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class PRINTC : Models.ScriptLine
    {
        private string _text;
        private string _color;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] r = Helper.Split(line);
            this._color = r[0];
            this._text = r[1];
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string s = Expression.INSTANCE.ReplaceVF(this._text, this.ScriptFile);
            string c = console.GetColor();
            console.SetTextColor(this._color);
            console.Write(s);
            console.SetTextColor(c);
        }
    }
}
