using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    interface IScreen
    {
        void Update(float delta);
        void Draw();
        void Dispose();

        Texture2D LoadTexture(string filepath);
        SpriteFont LoadFont(string filepath);
        Camera GetCamera();
    }
}
