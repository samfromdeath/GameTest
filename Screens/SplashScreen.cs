using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1.Screens
{
    public class SplashScreen : FormScreen
    {        
        public double ShowTime = 5000.0d;
        public Screen ShowScreen;
        
        public override void Update(GameTime gameTime)
        {
            ShowTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if(ShowTime < 0.0d)
            {
                ScreenManager.BackColor = Color.White;
                ShowScreen.Show();
            }
        }
    }
}
