using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Video : Item
    {
        public Writer writer { get; set; }
        public string subtiltles { get; set; }
        public void Deconstruct(out string Name, out string writerName, out string Year, out string Genr, out string text, out double Duration)
        {
            Name = itemName;
            writerName = writer.WriterName;
            Year = year;
            Genr = Genre.ToString();
            text = subtiltles;
            Duration = duration;
        }
    }


    public class Writer
    {
        private string writerName;
        internal List<string> writers = new List<string>();
        public string WriterName
        {
            get
            {
                if (writerName == null) { return "Unknown writer"; }
                else { return writerName; }
            }
            set
            {
                writerName = value;
                if (writers.Contains(writerName))
                {
                    writers.Add(writerName);
                }
            }
        }
    }
}