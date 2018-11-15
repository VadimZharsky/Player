using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Player
{
    [Serializable()]
    public class Song : Item
    {
        [System.Xml.Serialization.XmlElement("artist")]
        public Artist artist { get; set; }
       [System.Xml.Serialization.XmlElement("album")]
        public Album album { get; set; }
        [System.Xml.Serialization.XmlElement("lyrics")]
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
    [Serializable()]
    public class Artist
    {
        [System.Xml.Serialization.XmlElement("artistName")]
        private string artistName;
        [System.Xml.Serialization.XmlIgnore]
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
    [Serializable()]
    public class Album
    {
        [System.Xml.Serialization.XmlElement("albumName")]
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
}