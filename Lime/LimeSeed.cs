using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lime
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public abstract class LimeSeed : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public LimeSeed()
        {
            graphics = new GraphicsDeviceManager(this);
            ScreenResolution.Init(ref graphics);
            Content.RootDirectory = "Content";

            ScreenResolution.SetVirtualResolution((int)(GameOptions.SCREEN_WIDTH * GameOptions.V_SCREEN_FACTOR), ((int)(GameOptions.SCREEN_HEIGHT * GameOptions.V_SCREEN_FACTOR)));

        }

        protected abstract void CreateGame();

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected sealed override void Initialize()
        {
            ScreenResolution.SetResolution(GameOptions.SCREEN_WIDTH, GameOptions.SCREEN_HEIGHT, GameOptions.FULL_SCREEN);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected sealed override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.CreateGame();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected sealed override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected sealed override void Update(GameTime gameTime)
        {
            GameManager.Instance.Update(gameTime);
            Lime.Animation.GraphicsManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected sealed override void Draw(GameTime gameTime)
        {
            Lime.Animation.GraphicsManager.Instance.Draw(spriteBatch, GraphicsDevice);

            base.Draw(gameTime);
        }
    }
}
