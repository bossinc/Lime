using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lime
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Lime : Game
    {
        public const int ScreenWidth = 400;
        public const int ScreenHeight = 240;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Lime()
        {
            graphics = new GraphicsDeviceManager(this);
            ScreenResolution.Init(ref graphics);
            Content.RootDirectory = "Content";

            ScreenResolution.SetVirtualResolution(ScreenWidth, ScreenHeight);

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            ScreenResolution.SetResolution(ScreenWidth * 2,ScreenHeight * 2, false);           

            base.Initialize();
        }

        Texture2D test;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            test = Content.Load<Texture2D>("battleBG");
            SpriteRender spriteRender = new SpriteRender();
            AnimationController antimationController = new AnimationController();
            Animation animation = new Animation("test", new Point(0, 0), new Point(32, 32));
            antimationController.AddAnimation(animation);
            spriteRender.AnimationController = antimationController;
            Sprite sprite = new Sprite(Content);

            spriteRender.Sprite = sprite;

            GameObject gameObject = new GameObject();
            gameObject.AddComponent(spriteRender);

            GameManager.Instance.AddGameObject(gameObject);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            GameManager.Instance.Update();
            GraphicsManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Cyan);

            GraphicsManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
