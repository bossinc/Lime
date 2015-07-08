using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime.PseudoPhysics
{
    internal sealed class PseudoPhysicsManager
    {
        private static PseudoPhysicsManager _instance;
        public static PseudoPhysicsManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PseudoPhysicsManager();
                return _instance;
            }
        }

        private List<Collider> Colliders;

        public PseudoPhysicsManager()
        {
            this.Colliders = new List<Collider>();
        }

        public void AddCollider(Collider collider)
        {
            this.Colliders.Add(collider);
        }

        public void Update()
        {
            foreach (Collider collider in this.Colliders)
            {
                if (!collider.Stale)
                {
                    foreach (Collider subCollider in collider.CurColliders)
                    {
                        if (!collider.Intersects(subCollider))
                        {
                            collider.RemoveCurCollider(subCollider);
                            collider.Update();
                        }
                    }

                    foreach (Collider subCollider in this.Colliders)
                    {
                        if (collider.Intersects(subCollider))
                        {
                            collider.AddCurCollider(subCollider);
                            collider.Update();
                        }
                    }
                }
            }
        }
    }
}
