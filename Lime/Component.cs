using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    class Component
    {
        /// <summary>
        /// If the component is enabled, then it will be updated in the game loop.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return Enabled;
            }
            set
            {
                this.Enabled = value;
            }
        }

        /// <summary>
        /// The assocated GameObject.
        /// This GameObject will have this Component as a member.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return this.GameObject;
            }
            set
            {
                this.GameObject = value;
            }
        }

        public void Awake()
        {

        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Destroy()
        {

        }

        public void OnEnable()
        {

        }

        public void OnDisable()
        {

        }

        public void OnDestroy()
        {

        }
    }
}
