﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    public abstract class BaseObject
    {
        private static int IdIndexer
        {
            get
            {
                return _idIndexer++;
            }
        }
        private static int _idIndexer = 0;

        /// <summary>
        /// A unique ID generated by the Game
        /// </summary>
        public int InstanceId
        {
            get
            {
                return this._instanceId;
            }
            private set
            {
                this._instanceId = value;
            }
        }
        private int _instanceId;

        /// <summary>
        /// Activates an event each time Enabled is changed
        /// True: Object Updates
        /// False: Object does not Update
        /// </summary>
        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                if (value)
                {
                    if (this.EOnEnabled != null)
                        this.EOnEnabled(this);
                    if (this is GameObject)
                        ((GameObject)this).Enable();
                }
                else
                {
                    if (this.EOnDisabled != null)
                        this.EOnDisabled(this);
                    if (this is GameObject)
                        ((GameObject)this).Disable();
                }
                this._enabled = value;
            }
        }
        private bool _enabled;

        private double destroyWaitTime;

        public BaseObject()
        {
            _enabled = true;
        }

        protected void SetId()
        {
            this.InstanceId = IdIndexer;
        }

        /// <summary>
        /// Removes the BaseObject from the game
        /// </summary>
        /// <param name="baseObject">The object to be destroyed</param>
        /// <param name="waitTime">The amount of time to wait before destroying the object</param>
        public static void Destroy(BaseObject baseObject, double waitTime)
        {
            if (waitTime <= 0)
            {
                if (baseObject is Component)
                {
                    ((Component)baseObject).GameObject.DestroyComponent((Component)baseObject);
                }
                else if (baseObject is GameObject)
                {
                    GameManager.Instance.RemoveGameObject(baseObject as GameObject);
                }
                else
                {
                    throw new System.Exception("Cannot destroy " + baseObject.GetType().ToString());
                }
                //baseObject.OnDestroy(baseObject);
            }
            else
                baseObject.destroyWaitTime = waitTime;
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="gameTime">The current GameTime</param>
        public virtual void Update(GameTime gameTime)
        {
            if (destroyWaitTime > 0)
            {
                destroyWaitTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if (destroyWaitTime <= 0)
                    Destroy(this, 0);
            }
        }


        #region Delegates

        public delegate void ChangedEventHandler(BaseObject sender);

        #endregion Delegates

        #region Events

        internal event ChangedEventHandler OnDestroy;

        internal event ChangedEventHandler EOnEnabled;

        internal event ChangedEventHandler EOnDisabled;

        #endregion Events
    }
}
