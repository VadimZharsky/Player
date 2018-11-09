using Player.Skin;
using Player.Properties;
using System.Collections.Generic;

namespace Player
{
    public abstract class IPlayer
    {
        public ISkin actualSkin { get; set; }
        public PlayerProperties properties { get; set; }
        private bool playOrNot;
        bool isLocked { get; set; }
        List<Item> items = new List<Item>();
        public abstract void UploadItems<T>(T item) where T : Item;
        public abstract void Play(int numItem);
        public abstract void PlayNext();
        public abstract void PlayPrevious();
        public abstract void Clear();
        public abstract void ShuffleItems();
        public abstract void SortItems();
        public abstract void SearchItems();
        public abstract void SaveAs();
        public abstract void Load();

        public virtual void Stop()
        {
            playOrNot = false;
        }
    }
}
