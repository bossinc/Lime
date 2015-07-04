using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    abstract class Component : BaseObject
    {
        private GameObject _gameObject;
        /// <summary>
        /// The assocated GameObject.
        /// This GameObject will have this Component as a member.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return this._gameObject;
            }
            set
            {
                this._gameObject = value;
            }
        }


        public Component()
        {
        }

        public virtual void Start()
        {
            
        }

        // TODO:
    }
}
