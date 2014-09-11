using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0MingfengHan
{
    class KeyboardController : IController
    {

        private Dictionary<Keys, ICommand> keyCommandMap;

        private KeyboardState oldState;

        // creates a list of commands
        public KeyboardController(
            ICommand qCommand,
            ICommand wCommand,
            ICommand eCommand,
            ICommand rCommand
            )
        {
            keyCommandMap = new Dictionary<Keys,ICommand>();
            keyCommandMap.Add(Keys.Q, qCommand);
            keyCommandMap.Add(Keys.W, wCommand);
            keyCommandMap.Add(Keys.E, eCommand);
            keyCommandMap.Add(Keys.R, rCommand);
            oldState = Keyboard.GetState();
        }


        public void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.Q))
            {
                reactToKeyPressed(Keys.Q);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                reactToKeyPressed(Keys.W);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.E))
            {
                reactToKeyPressed(Keys.E);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.R))
            {
                reactToKeyPressed(Keys.R);
            }
        }

        private void reactToKeyPressed(Keys pressedKey)
        {
            // if key is pressed just now, run command
            ICommand runCommand;
            if (keyCommandMap.TryGetValue(pressedKey, out runCommand)) runCommand.ExecuteCommand();
            
        }
    }
}
