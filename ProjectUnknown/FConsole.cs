using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class FConsole
    {
        private bool _newline;
        private bool _reading;

        public FConsole()
        {
            //顺便说一下，Windows自带的cmd无法显示像 “ಠ౪ಠ” 一类的字符。为了获得良好的用户体验，我选择 Cmder
            //有问题，还是注释掉吧
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            this._newline = true;
            this._reading = false;
        }

        public void WriteLine(string text)
        {
            bool s = false;
            if(this._reading == true && this._newline == true)
            {
                Console.Write("\b\b \b");
                s = true;
            }
            this._newline = true;
            Console.WriteLine(text);

            if (s)
            {
                Console.Write("> ");//写回去
            }
                

        }

        public void Write(string text)
        {
            if (this._reading == true && this._newline == true)
            {
                Console.Write("\b\b \b");//消去> 
            }

            this._newline = false;
            Console.Write(text);

        }

        public void SetTextColor(string color)
        {
            try
            {
                ConsoleColor c = (ConsoleColor)System.Enum.Parse(typeof(ConsoleColor), color);
                Console.ForegroundColor = c;
            }catch
            {
                return;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public char ReadKey()
        {
            this._reading = true;
            char s = Console.ReadKey().KeyChar;
            this._reading = false;
            return s;
        }

        public string ReadLine()
        {
            if(this._newline)
                Console.Write("> ");
            this._reading = true;
            string s = Console.ReadLine();
            this._reading = false;
            return s;
        }

        public void setTitle(string title)
        {
            Console.Title = title;
        }

        public string GetColor()
        {
            return Console.ForegroundColor.ToString();
        }

    }
}
