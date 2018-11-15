using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Item
    {
        [Flags]
        public  enum Genres
        {
            notDefined = 0,
            pop = 1,
            rock = 2,
            metal = 4,
            alternative = 8,
            hiphop = 16,
            edm = 32,
            ebm = 64,
            wave = 128,
            Minimalsynth = 512,
            ambient = 1024, 
        }
        public string itemName { get; set; }
        public string year { get; set; }
        private Genres genre;
        public double duration { get; set; }
        public bool like { get; set; }
        public string path;
        public string extension;
        public Genres Genre
        {
            get
            {
                if (genre == 0)
                { return Genres.notDefined; }
                else { return genre; }
            }
            set
            {
                genre = value;
            }
        }
    }
    

    

}
