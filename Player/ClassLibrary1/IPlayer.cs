using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPlayer
{
    interface IPlayer
    {
        void UploadItems<T>(T item) where T : Item;
        void Play<T>(T item) where T:Item;
        void PlayNext();
        void PlayPrevious();
        void Stop();
        void Clear();
        void ShuffleItems();
        void SortItems();
        void SearchItems();
    }
}
