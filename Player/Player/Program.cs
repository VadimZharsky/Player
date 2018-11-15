using System;
using System.Collections.Generic;
using System.Threading;
using Player.Extension;
using Player.Skin;
using Player.Properties;
using System.IO;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {    
            List<Song> uploaded = new List<Song>();
            UploadSongs(@"data", ref uploaded);            
            foreach (Song song in uploaded)
            {
                Console.WriteLine(song.extension);
            }
            WavPlayer.PlayAsync(uploaded);

            //var actualSkin = SkinsMaker();
            //AudioPlayer audio = new AudioPlayer();
            //audio.actualSkin = actualSkin;
            //PlayerProperties prop = new PlayerProperties();
            //audio.properties = prop;
            ////audio.properties.LockPlay();
            //audio.ShuffleItems();
            //for (int i = 0; i < songs.Count; i++)
            //{
            //    audio.Play(i);
            //    //Thread.Sleep(1000);
            //}
            //audio.SaveAs();
            //audio.PlayNext();
            //audio.Load();
            //audio.Clear();
            //for (int i = 0; i < songs.Count; i++)
            //{

            //    audio.Play(i);
            //    Thread.Sleep(1000);
            //}
            Console.ReadKey();
        }
        public  void getMessage(string str)
        {
            Console.WriteLine(str);
        }

        
        private static ISkin SkinsMaker()
        {
            var rndSkin = new RandomColorSkin();
            var colorSkin = new ColorSkin() { SetColor = 3 };
            var classicSkin = new ClassicSkin();
            return rndSkin;
        }

        public static void UploadSongs(string path, ref List<Song> uploaded)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            Song song = null;
            List<FileInfo> files = new List<FileInfo>(dir.GetFiles("*.wav"));
            foreach (FileInfo file in files)
            {
                song = new Song();
                song.itemName = Path.GetFileNameWithoutExtension(file.FullName);
                song.path = Path.GetDirectoryName(file.FullName);
                song.extension = Path.GetExtension(file.FullName);
                uploaded.Add(song);
            }
        }
    }
}
