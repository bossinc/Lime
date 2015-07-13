using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Lime.Input
{
    enum LKeyState
    {
        Down,
        Pressed,
        Up,
        None
    }
    class InputManager
    {
        private List<InputKey> _inputKeys;
        public List<InputKey> InputKeys
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

        public void AddInputKey(InputKey inputKey)
        {
            this.InputKeys.Add(inputKey);
        }

        public void AddInputKey(string name, Keys key)
        {
            InputKey inputKey = new InputKey(name, key);
        }

        public void LoadDefaultKeys()
        {
            InputKey up = new InputKey("Up", Keys.A
        }

        public void Update()
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
                }
                else
                    inputKey.KeyState = LKeyState.None;
                inputKey.lastPressed = false;
            }
        }

        public LKeyState GetKeyState(string name)
        {
            LKeyState keyState = LKeyState.None;
            foreach (InputKey inputKey in this.InputKeys)
            {
                if (inputKey.Name == name)
                {
                    if (inputKey.KeyState == LKeyState.Down)
                        return inputKey.KeyState;
                    else if(inputKey.KeyState == LKeyState.Pressed)
                    {
                    }
                }
            }

            return keyState;
        }
    }
}
