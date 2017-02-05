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

        private bool _terminated = false;
        private string _filename;
        List<ScriptLine> _script;
        string[] _content;

        private Dictionary<string, string> _localvars;

        public ScriptFile(string file)
        {
            this._script = new List<ScriptLine>();
            this._localvars = new Dictionary<string, string>();
            this._filename = file;
            this.Reload();
        }


        public string GetLine(int i, bool trimIndent = true)
        {
            if (this._content == null || i < 0 || this._content.Length <= i) return String.Empty;

            if (trimIndent)
                return Helper.TrimIndent(this._content[i]);
            else
                return this._content[i];
        }

        public void Reload()
        {
            this._content = File.ReadAllLines(this._filename);

            for(int i = 0; i < _content.Length; ++i)
            {
                string l = this.GetLine(i);
                if (String.IsNullOrEmpty(l) || l[0] == ';') continue;//空行以及注释
                _script.Add(Helper.CreateScriptLine(l, ref i, this));
            }

        }

        public void Run(FConsole console)
        {
            foreach(var i in _script)
            {
                if (this._terminated) return;
                i.Run(console);
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
    }
}
