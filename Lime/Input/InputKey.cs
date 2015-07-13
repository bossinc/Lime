using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Lime.Input
{
    class InputKey
    {
        private string _name;
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

        private Keys _key;
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

        private LKeyState _keyState;
        public LKeyState KeyState
        {
            get
            {
                return this._keyState;
            }
            set
            {
            }
        }

        internal bool lastPressed;

        public InputKey(string name, Keys key)
        {
            this.Name = name;
            this.Key = key;
            lastPressed = false;
        }
    }
}
