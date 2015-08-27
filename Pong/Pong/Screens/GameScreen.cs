using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    class GameScreen : BaseScreen, IScreen
    {
        private Player p1;

        private Texture2D playerTex;

        public GameScreen(Game parent) 
            : base(parent)
        {
            playerTex = LoadTexture("Player");
            p1 = new Player(playerTex);
        }

        public void Update(float delta)
        {
            p1.Update(delta);
            camera.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                camera.Zoom += 1 * delta;
                camera.Rotation += MathHelper.Pi * delta;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                camera.Zoom -= 1 * delta;
                camera.Rotation -= MathHelper.Pi * delta;
            }
        }

        public void Draw()
        {
            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            p1.Draw(batch);
            batch.End();

        }

        public void Dispose()
        {
            content.Dispose();
            batch.Dispose();
        }
    }
}
