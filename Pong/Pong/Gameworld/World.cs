using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Gameworld.Entities;
using Pong.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Gameworld
{
    class World
    {
        private IScreen parent;
        public static int top, bottom, left, right;

        Player p1, p2;
        PlayerController c1, c2;
        Ball ball;

        public World(IScreen parent)
        {
            this.parent = parent;
            top = (int)(-parent.GetCamera().Viewport.Height * 0.5f);
            bottom = -top;
            left = (int)(-parent.GetCamera().Viewport.Width * 0.5f);
            right = -left;

            p1 = new Player(parent.LoadTexture("Player"));
            p2 = new Player(parent.LoadTexture("Player"));
            c1 = new PlayerController(Keys.W, Keys.S);
            c2 = new PlayerController(Keys.Up, Keys.Down);

            p1.Position = new Vector2(-parent.GetCamera().Viewport.Width * 0.45f, 0);
            p2.Position = new Vector2(parent.GetCamera().Viewport.Width * 0.45f, 0);

            ball = new Ball(parent.LoadTexture("Ball"));
        }

        public void Update(float delta)
        {
            c1.Update(p1);
            p1.Update(delta);

            c2.Update(p2);
            p2.Update(delta);

            ball.Update(delta);

            HorizontalCollision();
            VerticalCollision();
        }

        private void VerticalCollision()
        {
            // right collision
            if (ball.Hitbox.Right > p2.Hitbox.Left)
            {
                ball.Position = new Vector2(p2.Hitbox.Left - ball.Hitbox.Width * 0.5f, ball.Position.Y);

                if (ball.Hitbox.Intersects(p2.Hitbox))
                    ball.XVelocity = -(Math.Abs(ball.XVelocity) + Ball.VELOCITY_INCREASE);
                else
                {
                    p1.score++;
                    ball.Reset();
                }
            }
            // left collision
            else if (ball.Hitbox.Left < p1.Hitbox.Right)
            {
                ball.Position = new Vector2(p1.Hitbox.Right + ball.Hitbox.Width * 0.5f, ball.Position.Y);

                if (ball.Hitbox.Intersects(p1.Hitbox))
                    ball.XVelocity = Math.Abs(ball.XVelocity) + Ball.VELOCITY_INCREASE;
                else
                {
                    p2.score++;
                    ball.Reset();
                }
            }
        }

        private void HorizontalCollision()
        {
            // Top collision
            if (ball.Hitbox.Top < top)
            {
                ball.Position = new Vector2(ball.Position.X, top + ball.Hitbox.Height * 0.5f);
                ball.YVelocity = -ball.YVelocity;
            }
            // Bottom collision
            else if (ball.Hitbox.Bottom > bottom)
            {
                ball.Position = new Vector2(ball.Position.X, bottom - ball.Hitbox.Height * 0.5f);
                ball.YVelocity = -ball.YVelocity;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            p1.Draw(batch);
            p2.Draw(batch);
            ball.Draw(batch);
        }
    }
}
