using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Screens
{
    /// <summary>
    /// This is used for menu, etc
    /// </summary>
    public class FormScreen : Screen
    {
        public Texture2D BackgroundImage;        
        
        public override void Draw(GameTime gameTime)
        {
            if (BackgroundImage != null)
            {
                base._game.spriteBatch.Begin();                
                base._game.spriteBatch.Draw(BackgroundImage, Vector2.Zero);
                base._game.spriteBatch.End();
            }
        }
    }
}
