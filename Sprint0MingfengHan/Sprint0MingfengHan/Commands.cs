using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0MingfengHan
{
    // keyboard commands
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

    class AnimateCommand : ICommand
    {
        private IAnimatedSprite sprite;
        public AnimateCommand(IAnimatedSprite sprite)
        {
            this.sprite = sprite;
        }

        public void ExecuteCommand(GameTime gameTime)
        {
            this.sprite.Update(gameTime);
        }
    }
}
