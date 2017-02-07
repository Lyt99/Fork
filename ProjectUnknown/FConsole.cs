using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class FConsole
    {
        private bool newline;
        public FConsole()
        {
            //顺便说一下，Windows自带的cmd无法显示像 “ಠ౪ಠ” 一类的字符。为了获得良好的用户体验，我选择 Cmder
            //有问题，还是注释掉吧
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            this.newline = true;
        }

        public void WriteLine(string text)
        {
            this.newline = true;
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            this.newline = false;
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
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            if(this.newline)
                Console.Write("> ");
            return Console.ReadLine();
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
