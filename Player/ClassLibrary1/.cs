using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPlayer
{
    public class PlayerProperties
    {
        private double volume;
        public bool isLocked = false;
        private bool isPlaying = false;

        public double Volume
        {
            get { return volume; }
            set
            {
                if (value > 0)
                {
                    if (value > 100) { volume = 100; }
                    else { volume = value; }
                }
                else { volume = 0; }
            }
        }


        public void VolumeUp()
        {
            Volume++;
        }
        public void VolumeDown()
        {
            Volume--;
        }
        public bool LockPlay()
        {
            return isLocked = true;
        }
        public bool UnlockPlay()
        {
            return isLocked = false;
        }
        public bool Play()
        {
            if (isLocked == true)
            {
                Texter("Play mode is unavaible while lock mode");
                return isPlaying = true;
            }
            else
            {
                Texter("Playmode is activated");
                return isPlaying = false;
            }
        }
        public bool IsPlaying()
        {
            return (isPlaying == false) ? true : false;
        }
        public bool Stop()
        {
            Texter("Playmode is interrupted");
            return isPlaying = false;

        }
        private static void Texter(string str)
        {
            //Console.WriteLine(str);
        }
    }
}