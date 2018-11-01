using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPlayer
{
    static class PlaylistExtension
    {

        public static List<Song> SongsToPlay(this List<Song> songsToPlay, int choise)
        {
            switch (choise)
            {
                case 1:
                    songsToPlay = songsToPlay.OrderBy(obj => obj.itemName).ToList();
                    break;
                case 2:
                    songsToPlay = songsToPlay.OrderBy(obj => obj.artist).ToList();
                    break;
                case 3:
                    songsToPlay = songsToPlay.OrderBy(obj => obj.year).ToList();
                    break;
                case 4:
                    songsToPlay = songsToPlay.OrderBy(obj => obj.Genre).ToList();
                    break;
                case 5:
                    songsToPlay = songsToPlay.OrderBy(obj => obj.duration).ToList();
                    break;
            }
            return songsToPlay;
        }

        public static List<Song> ShuffleList(this List<Song> songsToPlay)
        {
            List<Song> tempList = new List<Song>();
            Random rnd = new Random();
            string s = "";
            string str = "";
            for (int i = 0; i < songsToPlay.Count; i++)
                s += i;
            while (str.Length < s.Length)
            {
                string x = rnd.Next(0, s.Length).ToString();
                if (!str.Contains(x))
                {
                    str += x;
                    tempList.Add(songsToPlay[Convert.ToInt32(x)]);
                }

            }
            return tempList;
        }
        public static List<Song> SortBySongList(this List<Song> songsToPlay, string searchParam, string searchWord)
        {
            List<Song> selectedList = new List<Song>();
            switch (searchParam)
            {
                case "songName":
                    foreach (Song song in songsToPlay)
                    {
                        if (song.itemName == searchWord)
                            selectedList.Add(song);
                    }
                    break;
                case "artist":
                    foreach (Song song in songsToPlay)
                    {
                        if (song.artist.ArtistName == searchWord)
                            selectedList.Add(song);
                    }
                    break;
                case "year":
                    foreach (Song song in songsToPlay)
                    {
                        if (song.year == searchWord)
                            selectedList.Add(song);
                    }
                    break;
                case "genre":
                    foreach (Song song in songsToPlay)
                    {
                        if (song.Genre.ToString().Contains(searchWord))
                            selectedList.Add(song);
                    }
                    break;
            }
            Console.WriteLine($"Found nexts songs \"{searchWord}\" in {searchParam}:");
            foreach (Song song in selectedList)
                Console.WriteLine($"   {song.itemName}");

            return selectedList;
        }
        public static string NameViewer<T>(this T item)where T:Item
        {
            string temp = string.Copy(item.itemName);
            if (item.itemName.Length > 13)
                return $"{temp.Remove(13, temp.Length - 13)}...";
            else { return temp; }
        }
        public static List<Video> VideoToPlay(this List<Video> videoToPlay, int choise)
        {
            switch (choise)
            {
                case 1:
                    videoToPlay = videoToPlay.OrderBy(obj => obj.itemName).ToList();
                    break;
                case 2:
                    videoToPlay = videoToPlay.OrderBy(obj => obj.writer).ToList();
                    break;
                case 3:
                    videoToPlay = videoToPlay.OrderBy(obj => obj.year).ToList();
                    break;
                case 4:
                    videoToPlay = videoToPlay.OrderBy(obj => obj.Genre).ToList();
                    break;
                case 5:
                    videoToPlay = videoToPlay.OrderBy(obj => obj.duration).ToList();
                    break;
            }
            return videoToPlay;
        }
        public static List<Video> SortByVideoList(this List<Video> videoToPlay, string searchParam, string searchWord)
        {
            List<Video> selectedList = new List<Video>();
            switch (searchParam)
            {
                case "songName":
                    foreach (Video video in videoToPlay)
                    {
                        if (video.itemName == searchWord)
                            selectedList.Add(video);
                    }
                    break;
                case "writer":
                    foreach (Video video in videoToPlay)
                    {
                        if (video.writer.WriterName == searchWord)
                            selectedList.Add(video);
                    }
                    break;
                case "year":
                    foreach (Video video in videoToPlay)
                    {
                        if (video.year == searchWord)
                            selectedList.Add(video);
                    }
                    break;
                case "genre":
                    foreach (Video video in videoToPlay)
                    {
                        if (video.Genre.ToString().Contains(searchWord))
                            selectedList.Add(video);
                    }
                    break;
            }
            Console.WriteLine($"Found nexts songs \"{searchWord}\" in {searchParam}:");
            foreach (Video video in selectedList)
                Console.WriteLine($"   {video.itemName}");

            return selectedList;
        }
        public static List<Video> ShuffleList(this List<Video> videoToPlay)
        {
            List<Video> tempList = new List<Video>();
            Random rnd = new Random();
            string s = "";
            string str = "";
            for (int i = 0; i < videoToPlay.Count; i++)
                s += i;
            while (str.Length < s.Length)
            {
                string x = rnd.Next(0, s.Length).ToString();
                if (!str.Contains(x))
                {
                    str += x;
                    tempList.Add(videoToPlay[Convert.ToInt32(x)]);
                }

            }
            return tempList;
        }
    }
    
}
