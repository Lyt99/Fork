using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjectFork.Models;
namespace ProjectFork
{
    class ScriptFile
    {
        public string FileName
        {
            get
            {
                return this._filename;
            }
        }

        public int Line
        {
            get
            {
                return this._content.Length;
            }
        }

        public void SetTerminated()
        {
            this._terminated = true;
        }

        public bool Terminated
        {
            get
            {
                return this._terminated;
            }
        }


        private bool _terminated = false;
        private string _filename;
        private List<ScriptLine> _script;
        private string[] _content;
        private ScriptLines.NOP _scriptline;

        private Dictionary<string, string> _localvars;

        public ScriptFile(string file)
        {
            this._filename = file;
            this._script = new List<ScriptLine>();
            this._localvars = new Dictionary<string, string>();
            this._scriptline = new ScriptLines.NOP();
            this.Reload();
        }

        public ScriptFile(ScriptFile file)
        {
            this._filename = file._filename;
            this._script = new List<ScriptLine>(file._script);
            this._content = file._content;
            this._localvars = new Dictionary<string, string>();
            this._scriptline = new ScriptLines.NOP();
        }

        public string GetLine(int i, bool trim = true)
        {
            if (this._content == null || i < 0 || this._content.Length <= i) return String.Empty;

            if (trim)
                return Helper.Trim(this._content[i]);
            else
                return this._content[i];
        }

        public void Reload()
        {
            this._content = File.ReadAllLines(this._filename, Encoding.UTF8);

            for(int i = 0; i < _content.Length; ++i)
            {
                string l = this.GetLine(i);
                if (String.IsNullOrEmpty(l) || l[0] == ';') continue;//空行以及注释
                _script.Add(Helper.CreateScriptLine(l, ref i, this, this._scriptline));
            }

        }

        public void Run(FConsole console)
        {
            foreach(var i in _script)
            {
                i.Run(console);
                if (this._terminated) return;
                if (this._scriptline.GetStatus() != 0) throw new Exceptions.RuntimeException("Unexpected BREAK/CONTINUE");

            }
            this._localvars.Clear();
        }

        public void SetLocalVars(string key, string value)
        {
            if (this._localvars.ContainsKey(key))
                this._localvars[key] = value;
            else
                this._localvars.Add(key, value);
        }

        public string GetLocalVars(string key)
        {
            return this._localvars.ContainsKey(key) ? this._localvars[key] : null;
        }

        public Dictionary<string, string> GetLocalVarDictionary()
        {
            return this._localvars;
        }

        public ScriptFile GetCopy()
        {
            return new ScriptFile(this);
        }
    }
}
