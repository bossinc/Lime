using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Lime.Input
{
    public class InputKey
    {
        /// <summary>
        /// The name of the InputKey
        /// This is used to identify the InputKey action
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        private string _name;

        /// <summary>
        /// The action key
        /// </summary>
        public Keys Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }
        private Keys _key;

        /// <summary>
        /// The current state of the Key
        /// </summary>
        public LKeyState KeyState
        {
            get
            {
                return this._keyState;
            }
            set
            {
                this._keyState = value;
            }
        }
        private LKeyState _keyState;

        internal bool lastPressed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name of the InputKey</param>
        /// <param name="key">The action key</param>
        public InputKey(string name, Keys key)
        {
            this.Name = name;
            this.Key = key;
            this.lastPressed = false;
            this.KeyState = LKeyState.None;
        }

        /// <summary>
        /// Loads some basic keys. These keys include:
        /// Up, Left, Right, Down, Action, Back, and Pause
        /// </summary>
        public static void LoadDefaultKeys()
        {
            //movement
            InputKey up = new InputKey("Up", Keys.W);
            InputKey upA = new InputKey("Up", Keys.Up);
            InputKey left = new InputKey("Left", Keys.A);
            InputKey leftA = new InputKey("Left", Keys.Left);
            InputKey right = new InputKey("Right", Keys.D);
            InputKey rightA = new InputKey("Right", Keys.Right);
            InputKey down = new InputKey("Down", Keys.S);
            InputKey downA = new InputKey("Down", Keys.Down);

            //other
            InputKey action = new InputKey("Action", Keys.Space);
            InputKey back = new InputKey("Back", Keys.Back);
            InputKey pause = new InputKey("Pause", Keys.Escape);

            GameManager.Instance.InputManager.InputKeys.Add(up);
            GameManager.Instance.InputManager.InputKeys.Add(upA);
            GameManager.Instance.InputManager.InputKeys.Add(left);
            GameManager.Instance.InputManager.InputKeys.Add(leftA);
            GameManager.Instance.InputManager.InputKeys.Add(right);
            GameManager.Instance.InputManager.InputKeys.Add(rightA);
            GameManager.Instance.InputManager.InputKeys.Add(down);
            GameManager.Instance.InputManager.InputKeys.Add(downA);
            GameManager.Instance.InputManager.InputKeys.Add(action);
            GameManager.Instance.InputManager.InputKeys.Add(back);
            GameManager.Instance.InputManager.InputKeys.Add(pause);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name of the InputKey</param>
        /// <returns>The current state of the InputKey</returns>
        public static LKeyState GetKeyState(string name)
        {
            LKeyState keyState = LKeyState.None;
            foreach (InputKey inputKey in GameManager.Instance.InputManager.InputKeys)
            {
                if (inputKey.Name == name)
                {
                    if (inputKey.KeyState == LKeyState.Down)
                        return inputKey.KeyState;
                    else if (inputKey.KeyState == LKeyState.Pressed)
                    {
                        keyState = inputKey.KeyState;
                    }
                    else if (inputKey.KeyState == LKeyState.Up)
                    {
                        if (keyState != LKeyState.Pressed)
                            keyState = inputKey.KeyState;
                    }
                }
            }

            return keyState;
        }
    }
}
