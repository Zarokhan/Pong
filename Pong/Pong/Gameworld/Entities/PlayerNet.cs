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

            }
        }
    }
}
