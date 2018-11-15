using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Properties
{
    public class PlayerProperties
    {
        public event PlayerHandler volumeChanged;
        public event PlayerHandler playerLocked;
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
                    else
                    {
                        volume = value;
                        volumeChanged?.Invoke($"volume changed at {volume}");
                    }
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
            playerLocked?.Invoke("player was locked");
            return isLocked = true;
        }
        public bool UnlockPlay()
        {
            playerLocked?.Invoke("player was unlocked");
            return isLocked = false;
        }

        public bool IsPlaying()
        {
            return (isPlaying == false) ? true : false;
        }

    }
}
