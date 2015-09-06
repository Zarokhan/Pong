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

        private BaseScreen parent;
        // Screen Bounds
        public static int top, bottom, left, right;

        private Player p1, p2;
        private PlayerController c1, c2;
        private PlayerAI playerAI, AI2;
        private Ball ball;

        private static bool failed_hit = false;
        
        public World(BaseScreen parent, GameMode mode)
        {
            this.parent = parent;
            // Static variables
            top = (int)(-parent.GetCamera().Viewport.Height * 0.5f);
            bottom = -top;
            left = (int)(-parent.GetCamera().Viewport.Width * 0.5f);
            right = -left;

            p1 = new Player(parent.LoadTexture("Player"));
            p2 = new Player(parent.LoadTexture("Player"));
            ball = new Ball(parent.LoadTexture("Ball"));
         
            p1.Position = new Vector2(-parent.GetCamera().Viewport.Width * 0.45f, 0);
            p2.Position = new Vector2(parent.GetCamera().Viewport.Width * 0.45f, 0);

            switch (mode)
            {
                case GameMode.AI:
                    //c1 = new PlayerController(Keys.Up, Keys.Down);
                    AI2 = new PlayerAI();
                    playerAI = new PlayerAI();
                    break;
                case GameMode.Versus:
                    c1 = new PlayerController(Keys.W, Keys.S);
                    c2 = new PlayerController(Keys.Up, Keys.Down);
                    break;
                case GameMode.Online:
                    break;
            }
        }

        public void Update(float delta)
        {
            if(c1 != null)
                c1.Update(p1);
            if (c2 != null)
                c2.Update(p2);
            if (playerAI != null)
                playerAI.Update(p2, ball);
            if (AI2 != null)
                AI2.Update(p1, ball);
            p1.Update(delta);
            p2.Update(delta);

            ball.Update(delta);

            HorizontalCollision(delta);
            VerticalCollision();
        }

        private void HorizontalCollision(float delta)
        {
            // Left collision
            if(ball.Position.X < 0)
            {
                if (failed_hit)
                {
                    Game.BackgroundColor = Color.Black;
                }
                else if(p1.Hitbox.Right > ball.Hitbox.Left + ball.XVelocity * delta)
                {
                    // Successful hit
                    if(ball.Position.Y > p1.Position.Y - p1.Origin.Y - ball.Origin.Y + 1 && ball.Position.Y < p1.Position.Y + p1.Origin.Y + ball.Origin.Y - 1)
                    {
                        // Return path
                        ball.Position = new Vector2(p1.Hitbox.Right + ball.Hitbox.Width * 0.5f, ball.Position.Y);
                        ball.XVelocity = (Math.Abs(ball.XVelocity) + Ball.VELOCITY_INCREASE);
                    } else
                    {
                        failed_hit = true;
                    }
                }
            }
            // Right collsision
            if (ball.Position.X > 0)
            {
                if (failed_hit)
                {
                    Game.BackgroundColor = Color.Black;
                }
                else if(p2.Hitbox.Left < ball.Hitbox.Right + ball.XVelocity * delta)
                {
                    // Successful hit
                    if (ball.Position.Y > p2.Position.Y - p2.Origin.Y - ball.Origin.Y + 1 && ball.Position.Y < p2.Position.Y + p2.Origin.Y + ball.Origin.Y - 1)
                    {
                        // Return path
                        ball.Position = new Vector2(p2.Hitbox.Left - ball.Hitbox.Width * 0.5f, ball.Position.Y);
                        ball.XVelocity = -(Math.Abs(ball.XVelocity) + Ball.VELOCITY_INCREASE);
                    } else
                    {
                        failed_hit = true;
                    }
                }
            }

            // Reset
            if(ball.Hitbox.Right < left)
            {
                p2.score++;
                ResetWorld();
            } else if(ball.Hitbox.Left > right)
            {
                p1.score++;
                ResetWorld();
            }
        }

        private void VerticalCollision()
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

        private void ResetWorld()
        {
            ball.Reset();
            failed_hit = false;
            p1.Reset();
            p2.Reset();
            Game.BackgroundColor = Color.Black;
        }

        public void Draw(SpriteBatch batch)
        {
            p1.Draw(batch);
            p2.Draw(batch);
            ball.Draw(batch);
        }
    }
}
