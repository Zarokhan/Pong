using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    abstract class MenuScreen : BaseScreen, IScreen
    {
        private int selectedEntry = 0;
        private string menuTitle;

        protected List<MenuEntry> menuEntries = new List<MenuEntry>();
        protected SpriteFont font;

        // Main constructor
        public MenuScreen(Game parent, string menuTitle)
            : base(parent)
        {
            this.menuTitle = menuTitle;
            font = LoadFont("scorefont");
        }

        // Controlls movement across menus
        public virtual void HandleInput()
        {
            if (Input.Clicked(Keys.Up))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }

            if (Input.Clicked(Keys.Down))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }

            if (Input.Clicked(Keys.Enter))
            {
                PerformSelectedAction(selectedEntry);
            }
        }

        // Handles exceptions if current menuEntry is invalid
        protected void PerformSelectedAction(int entryIndex)
        {
            try
            {
                menuEntries[entryIndex].Action();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Failed to perform action:");
                Console.WriteLine(ex.Message);
            }
        }

        public virtual void Update(float delta)
        {
            camera.Update(delta);
            HandleInput();

            for (int index = 0; index < menuEntries.Count; index++)
            {
                menuEntries[index].Update(delta);
                menuEntries[index].Position = new Vector2(-camera.Viewport.Width * 0.3f + menuEntries[index].Getwidth(),
                                                          (-camera.Viewport.Height * 0.0f + menuEntries[index].GetHeight())
                                                                                 + menuEntries[index].GetHeight() * index);
            }
        }

        public virtual void Draw()
        {
            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            // Update backwards so we can have it in the corner
            for (int index = 0; index < menuEntries.Count; index++)
            {
                MenuEntry menuEntry = menuEntries[index];

                menuEntry.isSelected = (index == selectedEntry);
                menuEntry.Draw(batch);
            }

            Vector2 titlePosition = new Vector2(font.MeasureString(menuTitle).X / 2,
                                                 -camera.Viewport.Height * 0.25f - font.MeasureString(menuTitle).Y) / 2;
            Color titleColor = Color.White;
            Vector2 titleOrigin = font.MeasureString(menuTitle) / 2;
            float titleScale = 1f;

            batch.DrawString(font, menuTitle, titlePosition, titleColor, 0, titleOrigin, titleScale, SpriteEffects.None, 0);

            batch.End();
        }

        public void Dispose()
        {
            content.Dispose();
            batch.Dispose();
        }
    }
}
