using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Player.Extension
{
    static class XmlWorkExtension
    {
        public static void GetXMLFromObject(this List<Song> songs)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Song>));
            TextWriter txtWriter = new StreamWriter("Playlist.xml");
            xs.Serialize(txtWriter, songs);
            txtWriter.Close();
        }
        public static List<Song> GetAnObjFromXML(this List<Song> deserialized)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load("Playlist.xml");
            XmlSerializer ser = new XmlSerializer(typeof(Song));
            XmlReader reader = XmlReader.Create("Playlist.xml");
            Song song = null;
            while (reader.Read())
            {

                if (reader.IsStartElement())
                {
                    if (reader.Name == "Song")
                    {

                        song = new Song();
                        deserialized.Add(song);
                        Console.WriteLine($"number is {reader.Name}");
                    }
                    if (reader.Name == "itemName")
                    {
                        //Console.WriteLine($"number is");
                        song.itemName = reader.ReadInnerXml();
                        reader.Read();
                    }
                    if (reader.Name == "AlbumName")
                    {
                        song.album = new Album() { AlbumName = reader.ReadInnerXml() };
                        reader.Read();
                    }
                    if (reader.Name == "ArtistName")
                    {
                        song.artist = new Artist() { ArtistName = reader.ReadInnerXml() };
                        reader.Read();
                    }

                    if (reader.Name == "year")
                    {
                        song.year = reader.ReadInnerXml();
                        reader.Read();
                    }
                    if (reader.Name == "lyrics")
                    {
                        song.lyrics = reader.ReadInnerXml();
                        reader.Read();
                    }
                    if (reader.Name == "Genre")
                    {
                        
                        GetGenre(song, reader.ReadInnerXml());
                        
                        reader.Read();
                    }
                    if (reader.Name == "duration")
                    {
                        song.duration = Convert.ToDouble(reader.ReadInnerXml());
                        reader.Read();
                    }
                }
            }
            return deserialized;
        }

        private static void GetGenre(Song song, string name)
        {
            switch (name)
            {
                case "pop":
                    song.Genre = Item.Genres.pop;
                    break;                    
                case "rock":
                    song.Genre = Item.Genres.rock;
                    break;
                case "metal":
                    song.Genre = Item.Genres.metal;
                    break;
                case "alternative":
                    song.Genre = Item.Genres.alternative;
                    break;
                case "hiphop":
                    song.Genre = Item.Genres.hiphop;
                    break;
                case "edm":
                    song.Genre = Item.Genres.edm;
                    break;
                case "ebm":
                    song.Genre = Item.Genres.ebm;
                    break;
                case "wave":
                    song.Genre = Item.Genres.wave;
                    break;
                case "Minimalsynth":
                    song.Genre = Item.Genres.Minimalsynth;
                    break;
                case "ambient":
                    song.Genre = Item.Genres.ambient;
                    break;
            }
        }
    }
}