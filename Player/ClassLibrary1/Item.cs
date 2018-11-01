using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPlayer
{
    public class Item
    {
        [Flags]
        public enum Genres
        {
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
            notDefined = 2048
        }
        public string itemName { get; set; }
        public string year { get; set; }
        internal Genres genre;
        public double duration { get; set; }
        public bool like { get; set; }

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
    public class Song : Item
    {
        public Artist artist { get; set; }
        public Album album { get; set; }
        public string lyrics { get; set; }

        public void Deconstruct(out string Name, out string artistName, out string AlbumName, out string Year, out string Genr, out string text, out double Duration)
        {
            Name = itemName;
            artistName = artist.ArtistName;
            AlbumName = album.AlbumName;
            Year = year;
            Genr = Genre.ToString();
            text = lyrics;
            Duration = duration;
        }
    }
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





    public class Artist
    {
        private string artistName;
        public List<string> artists = new List<string>();
        public string ArtistName
        {
            get
            {
                if (artistName == null) { return "Unknown artist"; }
                else { return artistName; }
            }
            set
            {
                artistName = value;
                if (artists.Contains(artistName))
                {
                    artists.Add(artistName);
                }
            }
        }
    }
    public class Album
    {
        private string albumName;
        public string AlbumName
        {
            get
            {
                if (albumName == null) { return "Unknown album"; }
                else { return albumName; }
            }
            set { albumName = value; }
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
