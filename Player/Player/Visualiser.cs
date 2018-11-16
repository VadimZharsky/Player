
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player.Skin;
using Player.Properties;
namespace Player
{
    class Visualizer   
    {
        ISkin actualSkin;
        WavPlayer wav;
        PlayerProperties properties;
        public Visualizer(ISkin actualSkin, WavPlayer wav, PlayerProperties properties)
        {
            this.actualSkin = actualSkin;
            this.wav = wav;
            this.properties = properties;
            actualSkin = this.actualSkin;
            properties = this.properties;
            wav.playerStarted += Messenger;
            wav.songListChanged += Messenger;
            properties.playerLocked += Messenger;
            properties.volumeChanged += Messenger;
        }
        private  void Messenger(string mess)
        {
            actualSkin.Render(mess);
        }
     }
}


