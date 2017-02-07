using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ProjectFork
{
    class SoundManager
    {
        public static SoundManager INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new SoundManager();
                return _instance;
            }
        }

        private static SoundManager _instance;
        public static string Path = "Sound\\";
        
        private string _path;
        private Dictionary<string, System.Media.SoundPlayer> _sounds;
        private string _BGM;

        public SoundManager()
        {
            this._BGM = null;
            this._sounds = new Dictionary<string, System.Media.SoundPlayer>();
            this._path = new DirectoryInfo(Path).FullName;
        }

        public void Start()
        {
            DirectoryInfo di = new DirectoryInfo(this._path);
            if (!di.Exists) di.Create();

            List<string> sounds = new List<string>();
            GetAllSounds(di, sounds);
            
            foreach(string i in sounds)
            {
                SoundPlayer sp = new SoundPlayer(i);
                sp.Load();
                this._sounds.Add(Helper.GetRPath(i, this._path), sp);
            }
        }

        public void PlayBGM(string name)
        {
            if (!String.IsNullOrEmpty(this._BGM))
                this.StopPlay(this._BGM);
            this.PlayLooping(name);
            this._BGM = name;
        }

        public void StopBGM()
        {
            this.StopPlay(this._BGM);
        }

        public void PlayLooping(string name)
        {
            this.GetSoundPlayer(name).PlayLooping();
        }

        public void PlaySound(string name)
        {
            this.GetSoundPlayer(name).Play();
        } 

        public void PlaySoundSync(string name)
        {
            this.GetSoundPlayer(name).PlaySync();
        }

        public void StopPlay(string name = null)
        {
            if (String.IsNullOrEmpty(name))
            {
                foreach (var i in this._sounds)
                {
                    if (i.Key == this._BGM) continue;
                    i.Value.Stop();
                }

            }
            else
            {
                this.GetSoundPlayer(name).Stop();
            }
        }

        public SoundPlayer GetSoundPlayer(string name)
        {
            if (!this._sounds.ContainsKey(name)) throw new Exceptions.ScriptNotFoundException(name);
            return this._sounds[name];
        }

        private void GetAllSounds(DirectoryInfo di, List<string> scriptlist)
        {
            foreach (var i in di.GetFiles("*.wav"))
            {
                scriptlist.Add(i.FullName);
            }

            foreach (var i in di.GetDirectories())
            {
                this.GetAllSounds(i, scriptlist);
            }
        }
    }   
}
