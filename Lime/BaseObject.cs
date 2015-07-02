using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    abstract class BaseObject
    {
        private static int _idIndexer = 0;
        private static int idIndexer
        {
            get
            {
                return _idIndexer++;
            }
        }

        private int _instanceId;
        public int instanceId
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

        private bool _enabled;
        public bool enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                if (value)
                    this.OnEnabled(this);
                else
                    this.OnDisabled(this);
                this._enabled = value;
            }
        }

        private double destroyWaitTime;

        public BaseObject()
        {
            this.OnCreated(this);
        }

        protected void SetId()
        {
            this.instanceId = idIndexer;
        }

        public void Destroy(BaseObject baseObject, double waitTime)
        {
            if (waitTime <= 0)
            {
                if (baseObject is Component)
                {
                    ((Component)baseObject).gameObject.DestroyComponent((Component)baseObject);
                }
                else if (baseObject is GameObject)
                {
                    GameManager.instance.RemoveGameObject((GameObject)baseObject);
                }
                else
                {
                    throw new System.Exception("Cannot destroy " + baseObject.GetType().ToString());
                }
                this.OnDestroy(this);
            }
            else
                destroyWaitTime = waitTime;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (destroyWaitTime > 0)
            {
                destroyWaitTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if(destroyWaitTime <= 0)
                    Destroy(this, 0);
            }
        }

        #region Delegates

        public delegate void ChangedEventHandler(BaseObject sender);

        #endregion Delegates

        #region Events

        public event ChangedEventHandler OnCreated;

        public event ChangedEventHandler OnDestroy;

        public event ChangedEventHandler OnEnabled;

        public event ChangedEventHandler OnDisabled;

        #endregion Events
    }
}
