using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class Program
    {
        private static Scripter _scripter;
        static void Main(string[] args)
        {
            Un4seen.Bass.BassNet.Registration("lyt1999131@hotmail.com", "2X534122312422");
            try
            {
                _scripter = Scripter.INSTANCE;
                _scripter.Load();
                SoundManager.INSTANCE.Start();
                DataManager.INSTANCE.Start();
                _scripter.Start();
                Commander.INSTANCE.Start();
            }
            catch (ApplicationException e)
            {
                Scripter.INSTANCE.Console.WriteLine(e.ToString());
            }
        }
    }
}
