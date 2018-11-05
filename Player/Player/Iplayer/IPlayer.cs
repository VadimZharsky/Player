using Player.Skin;
using Player.Properties;

namespace Player
{
    interface IPlayer
    {
        ISkin actualSkin { get; set; }
        PlayerProperties properties { get; set; }
        bool isLocked { get; set; }
        void UploadItems<T>(T item) where T : Item;
        void Play(int numItem);
        void PlayNext();
        void PlayPrevious();
        void Stop();
        void Clear();
        void ShuffleItems();
        void SortItems();
        void SearchItems();
    }
}
