using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Gameworld.Entities
{
    class PlayerController
    {
        private Keys up, down;

        public PlayerController(Keys up, Keys down)
        {
            this.up = up;
            this.down = down;
        }

        public void Update(Player player)
        {
            if (Keyboard.GetState().IsKeyDown(up))
                player.MoveUp();
            else if (Keyboard.GetState().IsKeyDown(down))
                player.MoveDown();
            else
                player.ApplyFriction();
        }
    }
}
