using System;
using System.Collections.Generic;
using System.Threading;
using Player.Extension;
using Player.Skin;
using Player.Properties;
using System.IO;

namespace Player
{
    static class Program
    {
         static void Main(string[] args)
        {
            PlayerStart();
            Console.ReadLine();
        }
        public static void PlayerStart()
        {
            var wavPlayer = new WavPlayer();
            var actualSkin = SkinsMaker();
            var properties = new PlayerProperties();
            var visualiser = new Visualizer(actualSkin, wavPlayer, properties);
            properties.Volume = 50;
            wavPlayer.actualSkin = actualSkin;
            wavPlayer.properties = properties;
            Management(properties, wavPlayer);
        }

        private static void Management(PlayerProperties properties, WavPlayer wavPlayer)
        {
            string cmd = Convert.ToString(Console.ReadLine());
            Switcher(cmd, properties, wavPlayer);
            Management(properties, wavPlayer);
        }

        private async static void Switcher(string cmd, PlayerProperties properties, WavPlayer wavPlayer)
        {
            switch (cmd)
            {
                case "lock":
                    {
                        properties.LockPlay();
                        break;
                    }
                case "unlock":
                    {
                        properties.UnlockPlay();
                        break;
                    }
                case "play":
                    {
                        await wavPlayer.PlayWav();
                        break;
                    }
                case "stop":
                    {
                        wavPlayer.Stop();
                        break;
                    }
                case "setvolume":
                    {
                        double temp = Convert.ToDouble(Console.ReadLine());
                        properties.Volume = temp;

                        break;
                    }
                case "volumeup":
                    {
                        properties.VolumeUp();
                        break;
                    }
                case "volumedown":
                    {
                        properties.VolumeDown();
                        break;
                    }
                case "exit":
                    {
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
                case "loadFolder":
                    {
                        wavPlayer.LoadFolder(@"data");
                        break;
                    }
                case "shuffle":
                    {
                        wavPlayer.ShuffleItems();
                        break;
                    }
                default:
                    Console.WriteLine("Not authorized command");
                    break;
            }
        }
        private static ISkin SkinsMaker()
        {
            var rndSkin = new RandomColorSkin();
            var colorSkin = new ColorSkin() { SetColor = 3 };
            var classicSkin = new ClassicSkin();
            return rndSkin;
        }
    }
}
