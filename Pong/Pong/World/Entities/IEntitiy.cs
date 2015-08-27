using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Entities
{
    interface IEntitiy
    {
        void Update(float delta);
        void Draw(SpriteBatch batch);
    }
}
