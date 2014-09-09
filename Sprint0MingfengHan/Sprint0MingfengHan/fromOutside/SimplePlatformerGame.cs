using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SimplePlatformer
{
    /// <summary>
    /// Simple code for a platformer game
    /// Created in 2013 by Jakob "xnafan" Krarup
    /// http://www.xnafan.net
    /// Distribute and reuse freely, but please leave this comment
    /// </summary>

    public class SimplePlatformerGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // tile and jumper
        private Texture2D _tileTexture, _jumperTexture;

        // jumper model class
        private Jumper _jumper;

        // board model class
        private Board _board;
        private Random _rnd = new Random();
        private SpriteFont _debugFont;

        public SimplePlatformerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set the window size
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 640;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // load textures
            _tileTexture = Content.Load<Texture2D>("tile");
            _jumperTexture = Content.Load<Texture2D>("jumper");

            // create jumper and board models(texture and spritebatch are passed in)
            _jumper = new Jumper(_jumperTexture, new Vector2(80, 80), _spriteBatch);
            _board = new Board(_spriteBatch, _tileTexture, 15, 10);

            // load the debug sprite font
            _debugFont = Content.Load<SpriteFont>("DebugFont");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();

            // Check to see if the user has exited
            if (checkExitKey(keyboardState, gamePadState))
            {
                base.Update(gameTime);
                return;
            }

            

            // for each update, update jumper and listen to keyboard
            _jumper.Update(gameTime);
            CheckKeyboardAndReact();
        }

        private void CheckKeyboardAndReact()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.F5)) { RestartGame(); }
            if (state.IsKeyDown(Keys.Escape)) { Exit(); }
        }

        private void RestartGame()
        {
            Board.CurrentBoard.CreateNewBoard();
            PutJumperInTopLeftCorner();
        }

        private void PutJumperInTopLeftCorner()
        {
            _jumper.Position = Vector2.One * 80;
            _jumper.Movement = Vector2.Zero;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);
            _spriteBatch.Begin();


            base.Draw(gameTime);

            // redraw the board and jumper
            _board.Draw();
            WriteDebugInformation();
            _jumper.Draw();



            _spriteBatch.End();
        }

        private void WriteDebugInformation()
        {
            string positionInText = string.Format("Position of Jumper: ({0:0.0}, {1:0.0})", _jumper.Position.X, _jumper.Position.Y);
            string movementInText = string.Format("Current movement: ({0:0.0}, {1:0.0})", _jumper.Movement.X, _jumper.Movement.Y);
            string isOnFirmGroundText = string.Format("On firm ground? : {0}", _jumper.IsOnFirmGround());

            DrawWithShadow(positionInText, new Vector2(10, 0));
            DrawWithShadow(movementInText, new Vector2(10, 20));
            DrawWithShadow(isOnFirmGroundText, new Vector2(10, 40));
            DrawWithShadow("F5 for random board", new Vector2(70, 600));
        }

        private void DrawWithShadow(string text, Vector2 position)
        {
            _spriteBatch.DrawString(_debugFont, text, position + Vector2.One, Color.Black);
            _spriteBatch.DrawString(_debugFont, text, position, Color.LightYellow);
        }

        bool checkExitKey(KeyboardState keyboardState, GamePadState gamePadState)
        {
            // Check to see whether ESC was pressed on the keyboard 
            // or BACK was pressed on the controller.
            if (keyboardState.IsKeyDown(Keys.Escape) ||
                gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
                return true;
            }
            return false;
        }
    }
}