using Game1.Screens;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Spashscreen;

            using(ScreenManager.CurrentGame = new TheGame())
            {
                ScreenManager.CurrentGame.Run();
            }
        }
    }
#endif
}
