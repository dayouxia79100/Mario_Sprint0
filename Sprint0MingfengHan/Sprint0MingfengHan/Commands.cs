using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0MingfengHan
{

    #region QuitCommand
    class QuitCommand : ICommand
    {

        private Game game;
        public QuitCommand(Game game)
        {
            this.game = game;
        }


        public void ExecuteCommand(GameTime gameTime)
        {
            this.game.Exit();
        }
    }
    #endregion

    #region AnimatedCommand
    public class AnimateCommand : ICommand
    {
        // here i had to use this abstract class instead of using interface, since I do not have a method in my interface.
        public BaseSprite Sprite { get; set; }
        private Sprint0Game game;
        public AnimateCommand(BaseSprite sprite, Sprint0Game game)
        {
            Sprite = sprite;
            this.game = game;
        }

        public void ExecuteCommand(GameTime gameTime)
        {
            game.CurrentSprite = Sprite;
            Sprite.Update(gameTime); 
        }
    }
#endregion
}
