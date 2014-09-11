using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0MingfengHan
{
    class GamePadController : IController
    {
        

        private Dictionary<ControllerButtonEnum, ICommand> controllerCommandMap;

        enum ControllerButtonEnum{
            Start,
            A,
            B,
            X
        }

        // creates a list of controllers
        public GamePadController(
            ICommand qCommand,
            ICommand wCommand,
            ICommand eCommand,
            ICommand rCommand
            )
        {
            controllerCommandMap = new Dictionary<ControllerButtonEnum,ICommand>();
            controllerCommandMap.Add(ControllerButtonEnum.Start, qCommand);
            controllerCommandMap.Add(ControllerButtonEnum.A, wCommand);
            controllerCommandMap.Add(ControllerButtonEnum.B, eCommand);
            controllerCommandMap.Add(ControllerButtonEnum.X, rCommand);
        }


        public void Update(GameTime gameTime)
        {
            //TODO this needs to be done
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);


            // if the button is not pressed before and button is pressed now, run the corresponding command
            // else if the button was previously pressed, keep doing it

            
            // TODO this code looks ugly, may need to refactor later.
            if (currentGamePadState.IsConnected)
            {
                if(currentGamePadState.Buttons.Start == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.Start);
                }
                else if(currentGamePadState.Buttons.A == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.A);
                }
                else if(currentGamePadState.Buttons.B == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.B);
                }
                else if(currentGamePadState.Buttons.X == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.X);
                }
            }
        }

        private void reactToButtonPressed(ControllerButtonEnum pressedButton)
        {

                ICommand runCommand;
                if (controllerCommandMap.TryGetValue(pressedButton, out runCommand)) runCommand.ExecuteCommand();

        }
    }

   
}
