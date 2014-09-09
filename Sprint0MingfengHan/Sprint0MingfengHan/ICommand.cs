using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0MingfengHan
{
    public interface ICommand
    {
        void ExecuteCommand(GameTime gameTime);
    }
}
