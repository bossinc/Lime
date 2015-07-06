using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    abstract class Component : BaseObject
    {
        /// <summary>
        /// The assocated GameObject.
        /// This GameObject will have this Component as a member.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return GetGameObject();
            }
        }


        public Component()
        {
        }

        public virtual void Start()
        {
            
        }

        public delegate GameObject DGetGameObject();
        public DGetGameObject GetGameObject;
    }
}
