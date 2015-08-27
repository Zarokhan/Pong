using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Entities
{
    class Player : Entity, IEntitiy
    {
        public Player(Texture2D texture)
            : base(texture, texture.Width, texture.Height)
        {
            this.texture = texture;
        }

        public void Update(float delta)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down) ||
                Keyboard.GetState().IsKeyDown(Keys.W))
                position.Y += 100 * delta;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) ||
                Keyboard.GetState().IsKeyDown(Keys.S))
                position.Y -= 100 * delta;

        }
    }
}
