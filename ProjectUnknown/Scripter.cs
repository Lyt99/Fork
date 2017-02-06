using ProjectFork.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class Scripter
    {

        public static Scripter INSTANCE
        {
            get
            {
                if (_instance == null)
                    _instance = new Scripter();
                return _instance;
            }
        }

        public FConsole Console
        {
            get
            {
                return this._console;
            }
        }

        public static string Path = "Script\\";

        private static Scripter _instance;

        private string _path;
        private Dictionary<string, ScriptFile> _filelist;
        private FConsole _console;
        
        public Scripter()
        {
            this._path = new DirectoryInfo(Path).FullName;
            this._console = new FConsole();
            this._filelist = new Dictionary<string, ScriptFile>();
        }


        public void Load()
        {
            DirectoryInfo di = new DirectoryInfo(this._path);
            if (!di.Exists) throw new ScriptNotFoundException(this._path);
            List<string> scripts = new List<string>();

            this.GetAllScripts(di, scripts);
            foreach (string i in scripts)
            {
                ScriptFile sf = new ScriptFile(this._path + i);
                _filelist.Add(i, sf);
            }
            
        }



        public void Start()
        {
            this.RunScript("Definition.zs");
            this.RunScript("Main.zs");
        }

        public void RunScript(string filename)
        {
            if (_filelist.ContainsKey(filename))
            {
                _filelist[filename].Run(_console);
            }
            else
            {
                throw new ScriptNotFoundException(filename);
            }
        }

        public ScriptFile GetScriptFile(string filename)
        {
            if (_filelist.ContainsKey(filename))
            {
                return _filelist[filename];
            }
            else
            {
                throw new ScriptNotFoundException(filename);
            }
        }

        private void GetAllScripts(DirectoryInfo di, List<string> scriptlist)
        {
            foreach (var i in di.GetFiles("*.zs"))
            {
                scriptlist.Add(Helper.GetRPath(i.FullName, this._path));
            }

            foreach(var i in di.GetDirectories())
            {
                this.GetAllScripts(i, scriptlist);
            }
        }
    }

}
