using System;

namespace Player.Skin
{
    public interface ISkin
    {
        void NewScreen();
        void Render(string text);
        void Render(Tuple<string, string, string, string, string, string, string> tuple);
        void Render(Tuple<string, string, string, string, string, string> tuple);
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

        public void Render(Tuple<string, string, string, string, string, string, string> tuple)
        {
            Console.WriteLine(tuple);
        }

        public void Render(Tuple<string, string, string, string, string, string> tuple)
        {
            Console.WriteLine(tuple);
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

        public void Render(Tuple<string, string, string, string, string, string, string> tuple)
        {
            Console.WriteLine(tuple);
        }

        public void Render(Tuple<string, string, string, string, string, string> tuple)
        {
            Console.WriteLine(tuple);
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
            Console.WriteLine($"*** *** ***\n{text}\n``` ``` ```");
        }

        public void Render(Tuple<string, string, string, string, string, string, string> tuple)
        {
            Console.WriteLine(tuple);
        }

        public void Render(Tuple<string, string, string, string, string, string> tuple)
        {
            Console.WriteLine(tuple);
        }
    }
}
