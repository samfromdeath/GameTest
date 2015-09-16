using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class ScreenManager
    {        
        public static List<Screen> Screens = new List<Screen>();
        public static TheGame CurrentGame;
        public static MouseState CurrentMouseState;
        public static MouseState PreviousMouseState;
        public static KeyboardState CurrentKeyboardState;
        public static KeyboardState PreviousKeyboardState;

        public static bool IsKeyDown(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }
        public static bool WasKeyPressed(Keys key)
        {
            return !CurrentKeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyDown(key);
        }

        public static Color BackColor;

        public static Screen GetScreen(string name)
        {
            foreach (var screen in Screens)
            {
                if (screen.Name == name)
                    return screen;
            }
            return null;
        }
        public static Screen GetScreen(int id)
        {
            foreach (var screen in Screens)
            {
                if (screen.Id == id)
                    return screen;
            }
            return null;
        }

        public static void SwitchStates(MouseState newMouseState, KeyboardState newKeyboardState)
        {
            PreviousKeyboardState = CurrentKeyboardState;
            PreviousMouseState = CurrentMouseState;

            CurrentKeyboardState = newKeyboardState;
            CurrentMouseState = newMouseState;
        }



        public static Screen ActiveScreen = null;
        
    }
}
