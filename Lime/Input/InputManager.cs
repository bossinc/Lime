using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Lime.Input
{
    public enum LKeyState
    {
        Down,
        Pressed,
        Up,
        None
    }
    internal class InputManager
    {
        private List<InputKey> _inputKeys;
        internal List<InputKey> InputKeys
        {
            get
            {
                return this._inputKeys;
            }
            private set
            {
                this._inputKeys = value;
            }
        }

        public InputManager()
        {
            this.InputKeys = new List<InputKey>();
        }

        internal void AddInputKey(InputKey inputKey)
        {
            this.InputKeys.Add(inputKey);
        }

        internal void AddInputKey(string name, Keys key)
        {
            InputKey inputKey = new InputKey(name, key);
        }

        internal void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            foreach (InputKey inputKey in this.InputKeys)
            {
                if (keyboardState.IsKeyDown(inputKey.Key))
                {
                    if (inputKey.lastPressed)
                    {
                        //down
                        inputKey.KeyState = LKeyState.Down;
                    }
                    else
                    {
                        //press
                        inputKey.KeyState = LKeyState.Pressed;
                    }
                    inputKey.lastPressed = true;
                }
                else if (inputKey.lastPressed)
                {
                    //up
                    inputKey.KeyState = LKeyState.Up;
                    inputKey.lastPressed = false;
                }
                else
                {
                    inputKey.KeyState = LKeyState.None;
                }
            }
        }
    }
}
