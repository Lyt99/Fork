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
