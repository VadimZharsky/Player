using System;
using System.Collections.Generic;
using Player.Extension;
using Player.Skin;
using Player.Properties;

namespace Player
{
    public delegate void PlayerHandler(string Message);

    public class AudioPlayer : IPlayer
    {
        public event PlayerHandler playerStarted;
        public event PlayerHandler songStarted;
        public event PlayerHandler songListChanged;
        public List<Song> songsToPlay = new List<Song>();
        private bool playOrNot = false;
        public bool isLocked { get; set; }
        private int numItem;

        public int NumItem
        {
            get
            { return numItem; }
            set
            {
                if (value >= songsToPlay.Count - 1) { numItem = songsToPlay.Count - 1; }
                else if (value < 0) { numItem = 0; }
                else { numItem = value; }
            }
        }
        public AudioPlayer()
        {

            playerStarted?.Invoke("PlayerStarted");
        }
        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = properties.isLocked; }
        }

        public override void SaveAs()
        {
            
            songsToPlay.GetXMLFromObject();
        }
        public override void Load()
        {
            songListChanged?.Invoke("songList was been loaded");
            List<Song> deserialized = new List<Song>();
            songsToPlay.Clear();
            songsToPlay = deserialized.GetAnObjFromXML();
        }

        public override void Play(int numItem)
        {
            if (!properties.isLocked)
            {
                if (songsToPlay.Count > 0)
                {
                    songStarted?.Invoke($"{songsToPlay[numItem].itemName} is playing now");
                    playOrNot = true;
                    //actualSkin.NewScreen();
                    actualSkin.Render(songsToPlay[numItem].itemName);
                    actualSkin.Render(GetData(songsToPlay[numItem]));
                }
                else { actualSkin.Render("There is no songs"); }
                
            }
                
            
        }

        public override void PlayNext()
        {
            if (numItem + 1 < songsToPlay.Count && playOrNot == true) { numItem++; }
            if (playOrNot) { Play(numItem); }
        }

        public override void PlayPrevious()
        {
            if (numItem - 1 >= 0 && playOrNot == true) { numItem--; }
            if (playOrNot) { Play(numItem); }
        }
        public override void Clear()
        {
            songListChanged?.Invoke("songList was been deleted");
            songsToPlay.Clear();
        }

        public override void SearchItems()
        {
            if (songsToPlay.Count > 0)
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
                songsToPlay = songsToPlay.SortBySongList(searchParam, searchWord);
            }
            else { NoSongs(); }
        }

        public override void ShuffleItems()
        {
            if (songsToPlay.Count > 0)
            {
                songsToPlay = songsToPlay.ShuffleList();
                songListChanged?.Invoke("songList was been changed");
            }
            else { NoSongs(); }
        }

        public override void SortItems()
        {
            if (songsToPlay.Count > 0)
            {
                Console.WriteLine("sort by :\n1.Song\n2.Artist\n3.year\n4.genre\n5.Duration");
                byte choise = Convert.ToByte(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        songsToPlay = songsToPlay.SongsToPlay(1);
                        break;
                    case 2:
                        songsToPlay = songsToPlay.SongsToPlay(2);
                        break;
                    case 3:
                        songsToPlay = songsToPlay.SongsToPlay(3);
                        break;
                    case 4:
                        songsToPlay = songsToPlay.SongsToPlay(4);
                        break;
                    case 5:
                        songsToPlay = songsToPlay.SongsToPlay(5);
                        break;
                }
                songListChanged?.Invoke("songList was been changed");
            }
            else { NoSongs(); }
        }

        public override void UploadItems<T>(T item)  
        {
            if (item is Song)
            {
                songsToPlay.Add(item as Song);
                songListChanged?.Invoke("songList was been changed");
            }
                
        }
        Tuple<string, string, string, string, string, string, string> GetData(Song songToPlay)
        {
            
            var (_, artist, album, year, genre, lyrics, duration) = songToPlay;
            string inminutes = Convert.ToString((int)duration / 60);
            string inseconds = Convert.ToString((int)duration % 60);
            return new Tuple<string, string, string, string, string, string, string>(artist + "\n", album + "\n", year + "\n", genre + "\n",
                lyrics + "\n", inminutes + " minutes ", inseconds + " seconds\n");
        }
        private void NoSongs()
        { Console.WriteLine("there is no any song.please before upload songs"); }
    }
}
