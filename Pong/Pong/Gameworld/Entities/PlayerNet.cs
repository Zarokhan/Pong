using Microsoft.Xna.Framework.Input;
using Pong.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Pong.Gameworld.Entities
{
    class PlayerNet
    {
        Player player;
        NetworkStream netStream;
        BinaryReader reader;
        BinaryWriter writer;

        public PlayerNet(Player player)
        {
            this.player = player;
        }

        public void Run(object client)
        {
            netStream = ((TcpClient)client).GetStream();
            writer = new BinaryWriter(netStream, Encoding.ASCII);
            reader = new BinaryReader(netStream, Encoding.ASCII);

            // Command Loop
            while(true)
            {
                if (Input.Holding(Keys.Up))
                {
                    player.MoveUp();
                    SendMessage(player.Position.ToString());
                    Console.WriteLine(player.Position.ToString());
                }
            }
        }

        private void SendMessage(string message)
        {
            if(writer != null)
            {
                writer.Write(message);
            }
        }
    }
}
