﻿using System;
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
            foreach (KeyValuePair<Keys, ICommand> entry in keyCommandMap)
            {
                reactToKeyPressed(entry.Key, gameTime);
            }
        }

        private void reactToKeyPressed(Keys pressedKey, GameTime gameTime)
        {

            // if the key is not pressed before and key is pressed now, run the corresponding command
            // else if the key was previously pressed, keep doing it
            KeyboardState newState = Keyboard.GetState();
            if (!oldState.IsKeyDown(pressedKey) && newState.IsKeyDown(pressedKey))
            {
                // if key is pressed just now, run command
                ICommand runCommand;
                if (keyCommandMap.TryGetValue(pressedKey, out runCommand)) runCommand.ExecuteCommand(gameTime);
                oldState = newState;
            }
            else if (oldState.IsKeyDown(pressedKey))
            {
                // if it is pressed before
                ICommand runCommand;
                if (keyCommandMap.TryGetValue(pressedKey, out runCommand)) runCommand.ExecuteCommand(gameTime);
            }

        }
    }
}
