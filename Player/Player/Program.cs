using System;
using System.Collections.Generic;
using System.Threading;
using Player.Extension;
using Player.Skin;
using Player.Properties;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            UploadSongs(songs);
            var actualSkin = SkinsMaker();
            AudioPlayer audio = new AudioPlayer();
            audio.actualSkin = actualSkin;
            PlayerProperties prop = new PlayerProperties();
            audio.properties = prop;
            //audio.properties.LockPlay();
            
            foreach (Song song in songs)
            {
                audio.UploadItems(song);    
            }
            audio.ShuffleItems();
            for (int i = 0; i < songs.Count; i++)
            {
                audio.Play(i);
                //Thread.Sleep(1000);
            }
            audio.SaveAs();
            audio.PlayNext();
            audio.Load();
            audio.Clear();
            for (int i = 0; i < songs.Count; i++)
            {

                audio.Play(i);
                Thread.Sleep(1000);
            }
            Console.ReadKey();
        }

        
        private static ISkin SkinsMaker()
        {
            var rndSkin = new RandomColorSkin();
            var colorSkin = new ColorSkin() { SetColor = 3 };
            var classicSkin = new ClassicSkin();
            return rndSkin;
        }

        public static void UploadSongs(List<Song> songs)
        {
            songs.Add(new Song() { itemName = "sans rémission", artist = new Artist(), year = "1998", duration = 140, Genre = 0 });
            songs.Add(new Song() { itemName = "In the name of Amun", artist = new Artist() { ArtistName = "Nile" }, year = "2007", duration = 251, Genre = Song.Genres.metal });
            songs.Add(new Song() { itemName = "Static Cold", artist = new Artist() { ArtistName = "Frozen Autumn" }, year = "2014", duration = 187, Genre = Song.Genres.Minimalsynth | Song.Genres.wave });
            songs.Add(new Song() { itemName = "Hinterland", artist = new Artist() { ArtistName = "Linea Aspera" }, year = "2005", duration = 134, Genre = Song.Genres.Minimalsynth | Song.Genres.wave });
            songs.Add(new Song() { itemName = "Anybody", artist = new Artist() { ArtistName = "Curren$y" }, year = "2000", duration = 274, Genre = Song.Genres.hiphop });
            songs.Add(new Song() { itemName = "L'été indien", album = new Album(), artist = new Artist() { ArtistName = "Joe Dassin" }, year = "1990", duration = 225, Genre = Song.Genres.pop });
            songs.Add(new Song() { itemName = "Im Wasser", artist = new Artist() { ArtistName = "Schwefelgelb" }, year = "2016", duration = 533, Genre = Song.Genres.ebm | Song.Genres.Minimalsynth });
            songs.Add(new Song() { itemName = "Orkidea", artist = new Artist() { ArtistName = "Kauan" }, year = "2010", duration = 421, Genre = Song.Genres.rock | Song.Genres.ambient });
            songs[0].album = new Album() { AlbumName = "Si dieu veut" };
            songs[1].album = new Album() { AlbumName = "What Should Not Be Unearthed" };
            songs[2].album = new Album() { AlbumName = "Is Anybody There?" };
            songs[3].album = new Album() { AlbumName = "Linea Aspera" };
            songs[4].album = new Album() { AlbumName = "Andretti 9/30" };
            songs[6].album = new Album() { AlbumName = "Den Umgekehrten Atem" };
            songs[7].album = new Album() { AlbumName = "Tietäjän laulu" };
            songs[0].lyrics = "Pour tous les quartiers de Marseille, sans rémission";
            songs[1].lyrics = "In the name of the God Amun I wage war";
            songs[2].lyrics = "On the ground Alone in static cold";
            songs[3].lyrics = "Let me tread your wilderness";
            songs[4].lyrics = "Exotics and low riders front my house I dreamed about it";
            songs[5].lyrics = "et l'on s'aimera encore, lorsque l'amour sera mort";
            songs[6].lyrics = "";
            songs[7].lyrics = "Hylätty. Sumun kuristama. Ilman sielua";
        }
    }
}
