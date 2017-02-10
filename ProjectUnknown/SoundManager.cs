using System;
using System.Collections.Generic;
using System.IO;

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
        private Dictionary<string, FSoundPlayer> _sounds;
        private string _BGM;

        public SoundManager()
        {
            Un4seen.Bass.Bass.BASS_Init(-1, 44100, Un4seen.Bass.BASSInit.BASS_DEVICE_DEFAULT, User32API.GetCurrentWindowHandle());
            this._BGM = null;
            this._sounds = new Dictionary<string, FSoundPlayer>();
            this._path = System.IO.Path.GetFullPath(Path);
        }

        public void Start()
        {
            DirectoryInfo di = new DirectoryInfo(this._path);
            if (!di.Exists) di.Create();

            List<string> sounds = new List<string>();
            GetAllSounds(di, sounds);
            
            foreach(string i in sounds)
            {
                FSoundPlayer sp = new FSoundPlayer(i);
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

        public void PauseBGM()
        {
            this.PausePlay(this._BGM);
        }

        public void ResumeBGM()
        {
            this.ResumePlay(this._BGM);
        }

        public void StopBGM()
        {
            this.StopPlay(this._BGM);
        }

        public void PlayLooping(string name)
        {
            this.GetSoundPlayer(name).PlayLooping();
        }

        public void PlaySoundSync(string name)
        {
            this.GetSoundPlayer(name).Play();
        }

        public void PausePlay(string name = null)
        {
            if (String.IsNullOrEmpty(name))
            {
                foreach (var i in this._sounds)
                {
                    if (i.Key == this._BGM) continue;
                    i.Value.Pause();
                }

            }
            else
            {
                this.GetSoundPlayer(name).Pause();
            }
        }

        public void ResumePlay(string name = null)
        {
            if (String.IsNullOrEmpty(name))
            {
                foreach (var i in this._sounds)
                {
                    if (i.Key == this._BGM) continue;
                    i.Value.Resume();
                }

            }
            else
            {
                this.GetSoundPlayer(name).Resume();
            }
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

        public FSoundPlayer GetSoundPlayer(string name)
        {
            if (!this._sounds.ContainsKey(name)) throw new Exceptions.ScriptNotFoundException(name);
            return this._sounds[name];
        }

        private void GetAllSounds(DirectoryInfo di, List<string> scriptlist)
        {
            foreach (var i in di.GetFiles())
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
