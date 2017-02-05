﻿using ProjectFork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class FOR : Models.ScriptLine
    {

        private string _varname;
        private string _listname;
        private int _mode = 0;//0-List 1-Range
        private List<ScriptLine> _body;

        private int _from;
        private int _to;
        
        public FOR()
        {
            this._body = new List<ScriptLine>();
        }

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            string[] r = line.Split(' ');
            if (r.Length <= 1 || r.Length >= 4) throw new Exceptions.ParserException(line, e);
            this._varname = r[0];
            if (r.Length == 2)
            {
                this._mode = 0;
                this._listname = r[1];
            }
            if(r.Length == 3)
            {
                this._mode = 1;
                this._from = Convert.ToInt32(Expression.INSTANCE.RandR(r[1]));
                this._to = Convert.ToInt32(Expression.INSTANCE.RandR(r[2]));
            }

            while (true)
            {
                string i = this.ScriptFile.GetLine(++e);
                if (i.ToUpper() == "ENDFOR") break;
                _body.Add(Helper.CreateScriptLine(i, ref e, script));
            }

        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            if(this._mode == 0)
            {

                var list = DataManager.INSTANCE.GetList(this._listname);
                if (list == null) throw new Exceptions.RuntimeException("Cant't find List: " + this._listname);
                bool break_token = false;
                foreach (var i in list)
                {
                    if (break_token) break;
                    this.ScriptFile.SetLocalVars(this._varname, i);
                    foreach (var i1 in this._body)
                    {

                        if (this.ScriptFile.Status == 1) break_token = true;

                        if (this.ScriptFile.Terminated || this.ScriptFile.Status != 0)
                        {
                            this.ScriptFile.Status = 0;
                            break;
                        }
                        i1.Run(console);
                    }
                }
                return;
            }
            if(this._mode == 1)
            {
                bool break_token = false;
                for(int i = this._from;i <= this._to;++i)
                {
                    if (break_token) break;
                    this.ScriptFile.SetLocalVars(this._varname, i.ToString());
                    foreach (var i1 in this._body)
                    {
                        if (this.ScriptFile.Status == 1) break_token = true;
                        if (this.ScriptFile.Terminated || this.ScriptFile.Status != 0) break;

                        i1.Run(console);
                    }
                }
            }
        }
    }
}
