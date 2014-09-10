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

        private GamePadState oldState;

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

            
            oldState = GamePad.GetState(PlayerIndex.One);
        }


        public void Update(GameTime gameTime)
        {
            //TODO this needs to be done
            GamePadState newState = GamePad.GetState(PlayerIndex.One);


            // if the button is not pressed before and button is pressed now, run the corresponding command
            // else if the button was previously pressed, keep doing it

            
            // TODO this code looks ugly, may need to refactor later.
            if (newState.IsConnected)
            {
                if(newState.Buttons.Start == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.Start);
                }
                else if(newState.Buttons.A == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.A);
                }
                else if(newState.Buttons.B == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.B);
                }
                else if(newState.Buttons.X == ButtonState.Pressed)
                {
                    reactToButtonPressed(ControllerButtonEnum.X);
                }
                oldState = newState;
            }
        }

        private void reactToButtonPressed(ControllerButtonEnum pressedButton)
        {

                ICommand runCommand;
                if (controllerCommandMap.TryGetValue(pressedButton, out runCommand)) runCommand.ExecuteCommand();

        }
    }

   
}
