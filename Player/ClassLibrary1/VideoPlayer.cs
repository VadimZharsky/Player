using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericPlayer
{
    public class VideoPlayer : IPlayer
    {
        public List<Video> videoToPlay = new List<Video>();
        private bool playOrNot = false;
        private int numVideo;
        public int NumVideo
        {
            get
            { return numVideo; }
            set
            {
                if (value >= videoToPlay.Count - 1) { numVideo = videoToPlay.Count - 1; }
                else if (value < 0) { numVideo = 0; }
                else { numVideo = value; }
            }
        }
        public void Clear()
        {
            videoToPlay.Clear();
        }

        public void Play<T>(T item) where T : Item
        {
            playOrNot = true;
            Console.WriteLine(item.itemName);
        }

        public void PlayNext()
        {
            if (numVideo + 1 < videoToPlay.Count && playOrNot == true) { numVideo++; }
            if (playOrNot) { Play(videoToPlay[numVideo]); }
        }

        public void PlayPrevious()
        {
            if (numVideo - 1 >= 0 && playOrNot == true) { numVideo--; }
            if (playOrNot) { Play(videoToPlay[numVideo]); }
        }

        public void SearchItems()
        {
            if (videoToPlay.Count > 0)
            {
                Console.WriteLine("search in :\n1.Songs\n2.Artists\n3.years\n4.genres");
                byte choise = Convert.ToByte(Console.ReadLine());
                string searchParam = "";
                switch (choise)
                {
                    case 1:
                        searchParam = "songName";
                        break;
                    case 2:
                        searchParam = "artist";
                        break;
                    case 3:
                        searchParam = "year";
                        break;
                    case 4:
                        searchParam = "genre";
                        break;
                }
                Console.WriteLine($"Input searching {searchParam} to make a playlist");
                string searchWord = Convert.ToString(Console.ReadLine());
                videoToPlay = videoToPlay.SortByVideoList(searchParam, searchWord);
            }
            else { NoSongs(); }
        }

        public void ShuffleItems()
        {
            if (videoToPlay.Count > 0)
            {
                videoToPlay = videoToPlay.ShuffleList();

            }
            else { NoSongs(); }
        }

        public void SortItems()
        {
            if (videoToPlay.Count > 0)
            {
                Console.WriteLine("sort by :\n1.Song\n2.Writer\n3.year\n4.genre\n5.Duration");
                byte choise = Convert.ToByte(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        videoToPlay = videoToPlay.VideoToPlay(1);
                        break;
                    case 2:
                        videoToPlay = videoToPlay.VideoToPlay(2);
                        break;
                    case 3:
                        videoToPlay = videoToPlay.VideoToPlay(3);
                        break;
                    case 4:
                        videoToPlay = videoToPlay.VideoToPlay(4);
                        break;
                    case 5:
                        videoToPlay = videoToPlay.VideoToPlay(5);
                        break;
                }
            }
            else
            {
                NoSongs();
            }
        }
        public void Stop()
        {
            playOrNot = false;
        }

        public void UploadItems<T>(T item) where T : Item
        {
            if (item is Video)
                videoToPlay.Add(item as Video);
        }

        Tuple<string, string, string, string, string, string> GetData(Video videoToPlay)
        {

            var (_, writer, year, genre, subtitles, duration) = videoToPlay;
            string inminutes = Convert.ToString((int)duration / 60);
            string inseconds = Convert.ToString((int)duration % 60);
            return new Tuple<string, string, string, string, string, string>(writer + "\n", year + "\n", genre + "\n",
                subtitles + "\n", inminutes + " minutes ", inseconds + " seconds\n");
        }
        private void NoSongs()
        { Console.WriteLine("there is no any song.please before upload songs"); }
    }
}

