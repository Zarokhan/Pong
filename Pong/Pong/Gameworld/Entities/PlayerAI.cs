using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Gameworld.Entities
{
    class PlayerAI
    {
        public PlayerAI()
        {

        }

        public void Update(Player player, Ball ball)
        {
            if (ball.Position.Y > player.Position.Y + player.Origin.Y * 0.8f)
                player.MoveDown();
            else if (ball.Position.Y < player.Position.Y - player.Origin.Y * 0.8f)
                player.MoveUp();
        }
    }
}
