using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Player
{
    class WavPlayer : SoundPlayer
    {
        public delegate void WavHandler(string str);
        public static event WavHandler alarm;

        public static async void Play(List<Song> songs)
        {
            alarm += Program.getMessage;
            await PlayAsync(songs);
            
            

        }
        private static async Task PlayAsync(List<Song> songs)
        {
            var task = new Task(() =>
            {
                foreach (Song song in songs)
                {
                    SoundPlayer player = new System.Media.SoundPlayer(GetFullPath(song));
                    try
                    {
                        player.PlaySync();
                        alarm?.Invoke($"now playing is {song.itemName}");
                        alarm?.Invoke($"{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(1000);
                        //player.Dispose();
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadKey();
                    }
                }
            });
            
            task.Start();
            await task;
        }

        private static string GetFullPath(Song song)
        {
            return $"{song.path}\\{song.itemName}{song.extension}";
        }
    }
}
