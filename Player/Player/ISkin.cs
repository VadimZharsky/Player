using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    interface ISkin
    {
        void NewScreen();
        void Render(string text);
    }
    public class ClassicSkin : ISkin
    {
        public void NewScreen()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
    public class ColorSkin : ISkin
    {
        public int SetColor { get; set; }
        public void NewScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public void Render(string text)
        {

            try
            {
                Console.BackgroundColor = (ConsoleColor)SetColor;
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.White;
            }

            Console.WriteLine(text);
        }
    }
    public class RandomColorSkin : ISkin
    {
        public void NewScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public void Render(string text)
        {
            Random rnd = new Random();
            Console.BackgroundColor = (ConsoleColor)rnd.Next(1, 16);
            Console.WriteLine(text);
        }
    }
}
