using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sprint0MingfengHan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Sprint0Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private KeyboardController keyboardController;
        private Texture2D marioTexture;
        private Texture2D shuttleTexture;
        private NonmovingAnimatedSprite nonMovingSprite;
        private UpAndDownNonAnimatedSprite upAndDownSprite;
        private LeftAndRightAnimatedSprite leftAndRightSprite;
        public static readonly int windowHeight = 340;
        public static readonly int windowWidth = 480;

        public Sprint0Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
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
            // create a keyboard controller and gamepad controller
            //keyboardController = new KeyboardController(null, null, null, null);
            // create a dictionary of keymap
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
            marioTexture = Content.Load<Texture2D>("smb_mario_sheet");
            shuttleTexture = Content.Load<Texture2D>("shuttle");
            nonMovingSprite = new NonmovingAnimatedSprite(marioTexture, new Vector2(80, 80), spriteBatch);
            upAndDownSprite = new UpAndDownNonAnimatedSprite(marioTexture, new Vector2(160, 80), spriteBatch, graphics);
            leftAndRightSprite = new LeftAndRightAnimatedSprite(marioTexture, new Vector2(240, 80), spriteBatch, graphics);


            ICommand quitCommand = new QuitCommand(this);
            ICommand nonmovingAnimatedCommand = new AnimateCommand(nonMovingSprite);
            ICommand upAndDownCommand = new AnimateCommand(upAndDownSprite);
            ICommand leftAndRightCommand = new AnimateCommand(leftAndRightSprite);

            keyboardController = new KeyboardController(
                quitCommand,
                nonmovingAnimatedCommand,
                upAndDownCommand,
                leftAndRightCommand);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            
            // TODO: Add your update logic here
            base.Update(gameTime);
            keyboardController.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            nonMovingSprite.Draw();
            upAndDownSprite.Draw();
            leftAndRightSprite.Draw();

            spriteBatch.End();
            // TODO: Add your drawing code here

            
        }

        
    }
}
