
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
            AudioPlayer player;
            PlayerProperties properties;
            public Visualizer(ISkin actualSkin, AudioPlayer player, PlayerProperties properties)
            {
                this.actualSkin = actualSkin;
                this.player = player;
                this.properties = properties;
                player.actualSkin = this.actualSkin;
                player.properties = this.properties;
                player.playerStarted += Messenger;
                player.songListChanged += Messenger;
                player.songStarted += Messenger;
                player.properties.playerLocked += Messenger;
                player.properties.volumeChanged += Messenger;
            

            }
            private static void Messenger(string mess)
            {
                Console.WriteLine(mess);
            }
        }
}


