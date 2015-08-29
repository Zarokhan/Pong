using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Gameworld.Entities
{
    class Player : Entity
    {
        public const float MAX_VELOCITY = 200f;
        public const float ACCELERATION = 20f;
        public const float RETARDATION = 15f;

        public int score;

        public Player(Texture2D texture)
            : base(texture, texture.Width, texture.Height)
        {
            
        }

        public override void Update(float delta)
        {
            base.Update(delta);
            position.Y += yVel * delta;

            yVel = MathHelper.Clamp(yVel, -MAX_VELOCITY, MAX_VELOCITY);

            Position = new Vector2(Position.X,
                MathHelper.Clamp(Position.Y, World.top + Hitbox.Height * 0.5f,
                World.bottom - Hitbox.Height * 0.5f));
        }

        public void MoveUp()
        {
            if (yVel > 0)
                yVel = 0;

            yVel -= ACCELERATION;
        }

        public void MoveDown()
        {
            if (yVel < 0)
                yVel = 0;

            yVel += ACCELERATION;
        }

        // Slowing down player
        public void ApplyFriction()
        {
            if (yVel < 11f && yVel > -11f)
                yVel = 0;

            if (yVel > 0)
                yVel -= RETARDATION;
            else if (yVel < 0)
                yVel += RETARDATION;
        }
    }
}
