using Microsoft.Xna.Framework.Graphics;
using Pong.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    class MenuScreen : BaseScreen, IScreen 
    {
        public MenuScreen(Game parent)
            : base(parent)
        {

        }

        public void Draw()
        {
            batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, camera.Transform);

            batch.End();
        }

        public void Update(float delta)
        {

        }

        public void Dispose()
        {
            content.Dispose();
        }
    }
}
