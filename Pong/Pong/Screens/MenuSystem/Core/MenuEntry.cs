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
        private Vector2 position;
        private SpriteFont font;

        protected string text;

        public event EventHandler<EventArgs> ClickedEvent;
        public bool isSelected;

        public MenuEntry(string text, SpriteFont font)
        {
            this.text = text;
            this.font = font;
        }

        protected internal virtual void Action()
        {
            if (ClickedEvent != null)
                ClickedEvent(this, new EventArgs());
        }

        public virtual void Update(float delta)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            Color color = isSelected ? Color.Yellow : Color.White;
            Vector2 origin = font.MeasureString(text) / 2;
            float scale = 1;
            float rotation = 0;
            batch.DrawString(font, text, position, color, rotation, origin, scale, SpriteEffects.None, 0);
        }
        public int Getwidth()
        {
            return (int)font.MeasureString(text).X;
        }

        public int GetHeight()
        {
            return (int)font.MeasureString(text).Y;
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
