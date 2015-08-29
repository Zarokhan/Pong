using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    class MenuEntry
    {
        private string text;
        private Vector2 position;
        private SpriteFont font;
        public bool isSelected;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public event EventHandler<EventArgs> Selected;

        protected internal virtual void Action()
        {
            if (Selected != null)
                Selected(this, new EventArgs());
        }

        public MenuEntry(string text, SpriteFont font)
        {
            this.text = text;
            this.font = font;
        }

        public virtual int Getwidth()
        {
            return (int)font.MeasureString(text).X;
        }

        public virtual int GetHeight()
        {
            return (int)font.MeasureString(text).Y;
        }

        public virtual void Update(float delta)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            Color color = isSelected ? Color.Yellow : Color.White;
            Vector2 origin = new Vector2(GetHeight() / 2, Getwidth() / 2);
            float scale = 1;
            float rotation = 0;
            batch.DrawString(font, text, position, color, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
