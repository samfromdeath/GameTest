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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

        BasicEffect basicEffect = null;

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

            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter
            (0, GraphicsDevice.Viewport.Width,     // left, right
            GraphicsDevice.Viewport.Height, 0,    // bottom, top
            0, 1);   

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        List<VertexPositionColor> vpt = new List<VertexPositionColor>();
        MouseState PrevM;
        bool NewLine = true;


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (vpt.Count > 0 && !NewLine)
                    vpt.Add(vpt.Last());
                vpt.Add(new VertexPositionColor(new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0), Color.Black));
                NewLine = false;
            }
            else if (PrevM.LeftButton == ButtonState.Pressed)
            {
                vpt.Add(new VertexPositionColor(new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0), Color.Black));
                NewLine = true;
            }
            // TODO: Add your update logic here
            PrevM = Mouse.GetState();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            basicEffect.CurrentTechnique.Passes[0].Apply();

            //var vertices = new VertexPositionColor[4];
            //vertices[0].Position = new Vector3(100, 100, 0);
            //vertices[0].Color = Color.Black;
            //vertices[1].Position = new Vector3(200, 100, 0);
            //vertices[1].Color = Color.Red;
            //vertices[2].Position = new Vector3(200, 200, 0);
            //vertices[2].Color = Color.Black;
            //vertices[3].Position = new Vector3(100, 200, 0);
            //vertices[3].Color = Color.Red;
            if ((int)(vpt.Count / 2.0f) > 0)
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vpt.ToArray(), 0, vpt.Count % 2 == 0 ? (int)(vpt.Count / 2.0f) : (int)((vpt.Count / 2.0f) - 0.5f));

            base.Draw(gameTime);
        }
    }
}
