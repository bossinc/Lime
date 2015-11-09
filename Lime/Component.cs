using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    public abstract class Component : BaseObject
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
        }
        public Component()
        {
        }

        public virtual void Start()
        {
            
        }

        internal virtual void StartInternal()
        {

            Start();
        }

        internal virtual void SetGameObject(GameObject gameObject)
        {
            this._gameObject = gameObject;
            Console.WriteLine("DSFDAS : " + GameObject.ToString());
        }
    }
}
