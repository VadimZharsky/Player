using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class WavPlayer : SoundPlayer
    {
        public event EventHandler dev;
        public static void PlayAsync(List<Song> songs)
        {
            foreach (Song song in songs)
            {
                var task = new Task(() =>
                {
                    SoundPlayer player = new System.Media.SoundPlayer(GetFullPath(song));
                    player.PlaySync();
                    //dev?.Invoke("ssdf");
                    Task.Delay(1000).Wait();
                    player.Dispose();
                });
                task.Start();
                task.Wait();    
            }
          
        }
        private static string GetFullPath(Song song)
        {
            return $"{song.path}\\{song.itemName}{song.extension}";
        }
    }
}
