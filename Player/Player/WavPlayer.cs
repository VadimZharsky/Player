using Player.Extension;
using Player.Properties;
using Player.Skin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading.Tasks;


namespace Player
{
    class WavPlayer
    {
        public delegate void PlayerHandler(string Message);
        public event PlayerHandler playerStarted;
        public event PlayerHandler songListChanged;
        
        public ISkin actualSkin;
        public PlayerProperties properties;
        public bool isPlaying = false;
        List<Song> loadedList = new List<Song>();

        public async Task PlayWav()
        {
            if (loadedList.Count > 0 && properties.isLocked == false)
            {
                foreach (Song song in loadedList)
                {
                    playerStarted?.Invoke(song.itemName);
                }
                isPlaying = true;
                await PlayAsync();
                
            }
            else if (properties.isLocked == true)
            { playerStarted?.Invoke($"player is locked"); }
            else { playerStarted?.Invoke($"playlist is empty. Upload before..."); }
        }
        private Task PlayAsync()
        {
            
                return Task.Run(() =>
                {
                    while (isPlaying)
                    {
                        foreach (Song song in loadedList)
                        {
                            SoundPlayer player = new System.Media.SoundPlayer(GetFullPath(song));
                            try
                            {
                                playerStarted?.Invoke($"now playing {song.itemName}");
                                player.PlaySync();

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                Console.ReadKey();
                            }
                            if (isPlaying == false)
                            {
                                playerStarted?.Invoke($"player has been stopped");
                                break;
                            }

                        }
                    }
                    
                });           
        }
        public void Stop()
        {
            isPlaying = false;
        }
        public void LoadPlaylist(List<Song> songs)
        {
            if (songs.Count >= 0)
            {
                loadedList.Clear();
                loadedList = songs;
                songListChanged?.Invoke("New playlist was uploaded");
            }
            else { songListChanged?.Invoke("there is no no songs in suggested playlist"); }
        }
        public void LoadFolder(string path)
        {
            loadedList.Clear();
            DirectoryInfo dir = new DirectoryInfo(path);
            Song song = null;
            List<FileInfo> files = new List<FileInfo>(dir.GetFiles("*.wav"));
            foreach (FileInfo file in files)
            {
                song = new Song();
                song.itemName = Path.GetFileNameWithoutExtension(file.FullName);
                song.path = Path.GetDirectoryName(file.FullName);
                song.extension = Path.GetExtension(file.FullName);
                loadedList.Add(song);
            }
            songListChanged?.Invoke("New folder was uploaded");
        }
        public  void SaveAsXML()
        {
            loadedList.GetXMLFromObject();
        }
        public void GetXML()
        {
            loadedList.Clear();
            loadedList.GetAnObjFromXML();
        }
        public  void ShuffleItems()
        {
            if (loadedList.Count >= 0)
            {
                loadedList = loadedList.ShuffleList();
                songListChanged?.Invoke("songList was been changed");
            }
            else { songListChanged?.Invoke("there is no no songs in suggested playlist"); }
        }

        private static string GetFullPath(Song song)
        {
            return $"{song.path}\\{song.itemName}{song.extension}";
        }
    }
}
