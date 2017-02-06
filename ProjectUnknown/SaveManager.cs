using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class SaveManager
    {
        public static SaveManager INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new SaveManager();
                return _instance;
            }
        }
        public static string Path = "SAV\\";

        private static SaveManager _instance;
        private string _path;

        public SaveManager()
        {
            this._path = new DirectoryInfo(Path).FullName;
        }


        public void Save(string name)//保存VARS和FLAGS
        {
            var vars = DataManager.INSTANCE.GetVarsDictionary();
            var flags = DataManager.INSTANCE.GetDictDictionary();

            StreamWriter sw = new StreamWriter(this._path + name);
            sw.WriteLine("VARS");
            foreach (var i in vars)
            {
                string s = String.Format("{0} {1}", i.Key, i.Value);
                sw.WriteLine(s);
            }

            sw.WriteLine("FLAGS");
            foreach (var i in vars)
            {
                string s = String.Format("{0} {1}", i.Key, i.Value);
                sw.WriteLine(s);
            }
        }

        public void Load(string name)
        {
            DataManager.INSTANCE.GetVarsDictionary().Clear();
            DataManager.INSTANCE.GetFlagsDictionary().Clear();
            StreamReader sw = new StreamReader(this._path + name);

            object dict = null;
            string s;
            while ((s = sw.ReadLine()) != null)
            {
                if (dict == null) continue;
                if (s == null) break;

                if (s == "VARS")
                {
                    dict = DataManager.INSTANCE.GetVarsDictionary();
                    continue;
                }

                if (s == "FLAGS")
                {
                    dict = DataManager.INSTANCE.GetFlagsDictionary();
                    continue;
                }

                string[] r = Helper.Split(s);
                if (dict is Dictionary<string, string>) ((Dictionary<string, string>)dict).Add(r[0], r[1]);
                if (dict is Dictionary<string, bool>) ((Dictionary<string, bool>)dict).Add(r[0], r[1] == "True" ? true : false);

            }
        }


        public void DoSave()
        {
            Scripter.INSTANCE.Console.Write("Please input a name：");
            string name = Scripter.INSTANCE.Console.ReadLine();
            this.Save(name);
        }

        public void DoLoad()
        {
            FConsole console = Scripter.INSTANCE.Console;
            DirectoryInfo di = new DirectoryInfo(this._path);
            var list = di.GetFiles("*.sav");
            int count = list.Length;
            if (count == 0)
            {
                console.WriteLine("No save data.");
                return;
            }

            console.WriteLine("Please select:");
            for(int i = 0;i < count; ++i)
            {
                string s = String.Format("[{0}]{1} {2}", i, list[i].Name, list[i].LastWriteTime.ToString());
            }

            while (true) {
                try
                {
                    int selection = Convert.ToInt32(console.ReadLine());
                    this.Load(list[selection].Name);
                }
                catch
                {
                    console.WriteLine("Invaild selection.");
                }
                }


        }

    }
}
