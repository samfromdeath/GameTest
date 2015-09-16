using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Screens.Controls
{
    public class Button
    {
        private Texture2D NormalImage;
        private Texture2D HoverImage;
        private Texture2D PressedImage;
        public string Text;
        public Rectangle Bounds;
    }
}
