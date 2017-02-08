using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace ProjectFork
{
    class FSoundPlayer
    {
        private string _path;
        private int _stream;
        private bool _loaded;

        //卧槽，BASS这个库好用极了
        public FSoundPlayer(string path)
        {
            this._path = path;
            this._loaded = false;
        }


        public bool Load()
        {

            this._stream = Bass.BASS_StreamCreateFile(this._path, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);
            if (this._stream != 0)
            {
                this._loaded = true;
                return true;
            }
            else
                return false; 
        }

        public void Play()
        {
            if (!this._loaded) this.Load();
            Bass.BASS_ChannelFlags(this._stream, 0, BASSFlag.BASS_SAMPLE_LOOP);
            Bass.BASS_ChannelPlay(this._stream, false);
        }

        public void PlayLooping()
        {
            Bass.BASS_ChannelFlags(this._stream,BASSFlag.BASS_SAMPLE_LOOP, BASSFlag.BASS_SAMPLE_LOOP);
            Bass.BASS_ChannelPlay(this._stream, true);
        }

        public void Stop()
        {
            Bass.BASS_ChannelStop(this._stream);
        }


    }
}
