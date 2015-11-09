using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime.PseudoPhysics
{
    internal sealed class PseudoPhysicsManager
    {
        private List<Collider> Colliders;

        public PseudoPhysicsManager()
        {
            this.Colliders = new List<Collider>();
        }

        internal void AddCollider(Collider collider)
        {
            this.Colliders.Add(collider);
        }

        internal void DeleteCollider(Collider collider)
        {
            this.Colliders.Remove(collider);
        }

        internal void Update()
        {
            try
            {
                foreach (Collider collider in this.Colliders)
                {
                    collider.Update();
                    if (!collider.Stale)
                    {
                        foreach (Collider subCollider in collider.CurColliders)
                        {
                            if (!collider.Intersects(subCollider))
                            {
                                collider.RemoveCurCollider(subCollider);
                            }
                        }

                        foreach (Collider subCollider in this.Colliders)
                        {
                            if (collider.Intersects(subCollider))
                            {
                                collider.AddCurCollider(subCollider);
                            }
                        }
                    }
                }
            }

            catch (InvalidOperationException)
            {
            }
            catch (NullReferenceException)
            {
                this.Colliders.RemoveAll(x => x == null);
            }
        }
    }
}
