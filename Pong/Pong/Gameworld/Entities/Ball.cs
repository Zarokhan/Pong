using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Gameworld.Entities
{
    class Ball : Entity
    {
        public const int VELOCITY_INCREASE = 50;

        private float resetTimer;

        public Ball(Texture2D texture)
            : base(texture, texture.Width, texture.Height)
        {
            resetTimer = 0;
            Reset();
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            if (resetTimer > 0)
            {
                resetTimer -= delta;
            }
            else
            {
                position.Y += yVel * delta;
                position.X += xVel * delta;
            }
        }

        public void Reset()
        {
            resetTimer = 2.0f;

            position = new Vector2(0, 0);

            do
            { xVel = Game.rnd.Next(-200, 200); }
            while (xVel < 100 && xVel > -100);

            do
            { yVel = Game.rnd.Next(-200, 200); }
            while (yVel < 100 && yVel > -100);
        }

        public float XVelocity
        {
            get { return xVel; }
            set { xVel = value; }
        }

        public float YVelocity
        {
            get { return yVel; }
            set { yVel = value; }
        }
    }
}
