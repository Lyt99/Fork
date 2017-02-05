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

        public static string Path;

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
            foreach (var i in di.GetFiles("*.zs"))
            {
                string path = Helper.GetRPath(i.FullName, this._path);
                ScriptFile sf = new ScriptFile(i.FullName);
                _filelist.Add(path, sf);
            }
            
        }

        public void Start()
        {
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
    }
}
