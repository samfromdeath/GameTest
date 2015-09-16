using Game1.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TheGame : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        

        public TheGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.AllowAltF4 = true;
            this.graphics.PreferredBackBufferHeight = 1080;
            this.graphics.PreferredBackBufferWidth = 1920;
            this.graphics.IsFullScreen = true;
       
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            // TODO: use this.Content to load your game content here

            SplashScreen Splashscreen = new SplashScreen();
            Splashscreen.BackgroundImage = ScreenManager.CurrentGame.Content.Load<Texture2D>("Logo");
            Splashscreen.ShowScreen = new MainScreen();

            Splashscreen.Show();

            if (ScreenManager.ActiveScreen != null)
                ScreenManager.ActiveScreen.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            if (ScreenManager.ActiveScreen != null)
                ScreenManager.ActiveScreen.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {            
            ScreenManager.SwitchStates(Mouse.GetState(), Keyboard.GetState());

            if (ScreenManager.WasKeyPressed(Keys.Escape))
                Exit();

            if(ScreenManager.WasKeyPressed(Keys.F11))
                graphics.ToggleFullScreen();

            if (ScreenManager.ActiveScreen != null)
            {                
                ScreenManager.ActiveScreen.Update(gameTime);
            }            
        }        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ScreenManager.BackColor);
            // TODO: Add your drawing code here
            //basicEffect.CurrentTechnique.Passes[0].Apply();
            if(graphics.BeginDraw())
            {
                if (ScreenManager.ActiveScreen != null)
                    ScreenManager.ActiveScreen.Draw(gameTime);

                graphics.EndDraw();
            }            
        }
    }
}
