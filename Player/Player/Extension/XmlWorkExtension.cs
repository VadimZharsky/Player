using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Player;
using static Player.Item;

namespace Player.Extension
{
    static class XmlWorkExtension
    {
        public static void GetXMLFromObject(this List<Song> items)
        {
            TextWriter txtWriter = new StreamWriter("Playlist.xml");
            List<Song> songs = items as List<Song>;
            XmlSerializer xs = new XmlSerializer(typeof(List<Song>));
            xs.Serialize(txtWriter, songs);
            txtWriter.Close();
        }
        public static List<Song> GetAnObjFromXML(this List<Song> deserialized)
        {
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
            string[] genresArray = name.Split(' ');
            foreach (string s in genresArray)
            {
                //DOESN'T WORK RIGHT. ONLY RECEIVE ONE GENRE INSTEAD TWO
                song.Genre = (Genres)Enum.Parse(typeof(Genres), s);
            }
        }
    }
}