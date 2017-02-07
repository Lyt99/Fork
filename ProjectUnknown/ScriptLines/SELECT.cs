using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SELECT : Models.ScriptLine
    {
        private string _var;
        private char[] _selection;
        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] i = line.Split(' ');
            if (i.Length != 2) throw new Exceptions.ParserException(line, e, script);

            this._var = i[0];
            string[] selection = i[1].Split(',');
            List<char> wa = new List<char>();
            foreach(var a in selection)
            {
                wa.Add(a.ToLower()[0]);
            }

            this._selection = wa.ToArray();
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            string k = Expression.INSTANCE.ReplaceVF(this._var, this.ScriptFile);
            while (true)
            {
                char r = console.ReadKey();
                r = r.ToString().ToLower()[0];
                if(this._selection.Contains(r))
                {
                    this.ScriptFile.SetLocalVars(k, r.ToString());
                    console.WriteLine("");
                    break;
                }
                console.WriteLine("Invalid selection");
            }


        }
    }
}
