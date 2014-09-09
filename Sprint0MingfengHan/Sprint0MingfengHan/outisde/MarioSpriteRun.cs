using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteFonts
{


    public class MarioSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private float timeSinceLastUpdate = 0f;

        private int x = 238, y = 51;
 
        public MarioSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }
 
        public void Update(GameTime gameTime)
        {
            timeSinceLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastUpdate  > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
                timeSinceLastUpdate = 0f;

            }
           
        }
 
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 18;
            int height = 34;
            
 
            Rectangle sourceRectangle = new Rectangle(x+ currentFrame*30, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

}
