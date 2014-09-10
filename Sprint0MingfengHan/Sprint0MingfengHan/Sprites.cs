using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0MingfengHan
{
    #region BaseSprite
    public abstract class BaseSprite : IAnimatedSprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { set; get; }
        public SpriteBatch SpriteBatch { get; set; }

        public BaseSprite(Texture2D texture, Vector2 position, SpriteBatch batch)
        {
            Texture = texture;
            Position = position;
            SpriteBatch = batch;
        }
        public virtual void Draw()
        {
            SpriteBatch.Draw(Texture, Position, Color.White);
        }

        // child class must override this
        public abstract void Update(GameTime gameTime);
    }

    #endregion

    #region NonmovingAnimatedSprite
    public class NonmovingAnimatedSprite : BaseSprite
    {
        protected int currentFrame;
        protected int totalFrames;
        protected float timeSinceLastUpdate = 0f;
        protected readonly int x = 238, y = 51;
        protected readonly int width = 18;
        protected readonly int height = 34;
        protected readonly int distanceBetweenSprites = 30;
        public NonmovingAnimatedSprite(Texture2D texture, Vector2 position, SpriteBatch batch)
            : base(texture, position, batch)
        {

            currentFrame = 0;
            totalFrames = 3;
        }

        public override void Update(GameTime gameTime)
        {

            timeSinceLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
                timeSinceLastUpdate = 0f;

            }
        }

        public override void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(x + currentFrame * distanceBetweenSprites, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            SpriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
    #endregion

    #region UpAndDownNonAnimatedSprite
    public class UpAndDownNonAnimatedSprite : BaseSprite
    {
        private readonly int x = 238, y = 51;
        private readonly int width = 18;
        private readonly int height = 34;

        // i created this
        private Vector2 spriteSpeed = new Vector2(0.0f, 50.0f);
        private GraphicsDeviceManager graphics;
        public UpAndDownNonAnimatedSprite(Texture2D texture, Vector2 position, SpriteBatch batch, GraphicsDeviceManager graphics)
            : base(texture, position, batch)
        {
            this.graphics = graphics;
        }


        public override void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(x, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            SpriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            bounce(gameTime);
        }

        // note that even though this method is named this way, what it really does is bounce in all directions.
        private void bounce(GameTime gameTime)
        {
            Position +=
        spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - height;
            int MinY = 0;

            // Check for bounce.
            if (Position.X > MaxX)
            {
                spriteSpeed.X *= -1;
                //Position.X = MaxX;
                Position = new Vector2(MaxX, Position.Y);
            }

            else if (Position.X < MinX)
            {
                spriteSpeed.X *= -1;
                //Position.X = MinX;
                Position = new Vector2(MinX, Position.Y);
            }

            if (Position.Y > MaxY)
            {
                spriteSpeed.Y *= -1;
                //Position.Y = MaxY;
                Position = new Vector2(Position.X, MaxY);
            }

            else if (Position.Y < MinY)
            {
                spriteSpeed.Y *= -1;
                //Position.Y = MinY;
                Position = new Vector2(Position.X, MinY);
            }

        }
    }

    #endregion

    #region LeftAndRightAnimatedSprite
    public class LeftAndRightAnimatedSprite : NonmovingAnimatedSprite
    {
        private Vector2 spriteSpeed = new Vector2(50.0f, 0.0f);
        private GraphicsDeviceManager graphics;
        public LeftAndRightAnimatedSprite(Texture2D texture, Vector2 position, SpriteBatch batch, GraphicsDeviceManager graphics)
            : base(texture, position, batch)
        {
            this.graphics = graphics;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            bounce(gameTime);

        }

        // TODO this code is repeated from Upanddown mario, refactor it later! 
        private void bounce(GameTime gameTime)
        {
            Position +=
        spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - height;
            int MinY = 0;

            // Check for bounce.
            if (Position.X > MaxX)
            {
                spriteSpeed.X *= -1;
                //Position.X = MaxX;
                Position = new Vector2(MaxX, Position.Y);
            }

            else if (Position.X < MinX)
            {
                spriteSpeed.X *= -1;
                //Position.X = MinX;
                Position = new Vector2(MinX, Position.Y);
            }

            if (Position.Y > MaxY)
            {
                spriteSpeed.Y *= -1;
                //Position.Y = MaxY;
                Position = new Vector2(Position.X, MaxY);
            }

            else if (Position.Y < MinY)
            {
                spriteSpeed.Y *= -1;
                //Position.Y = MinY;
                Position = new Vector2(Position.X, MinY);
            }

        }

    }
#endregion
}

