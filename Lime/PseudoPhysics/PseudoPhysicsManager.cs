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
        private List<Collider> toAdd;
        private List<Collider> removeFrom;

        internal PseudoPhysicsManager()
        {
            this.Colliders = new List<Collider>();
            this.toAdd = new List<Collider>();
            this.removeFrom = new List<Collider>();
        }

        internal void AddCollider(Collider collider)
        {
            this.toAdd.Add(collider);
        }

        internal void DeleteCollider(Collider collider)
        {
            this.removeFrom.Remove(collider);
        }

        internal void Update()
        {
            List<GameObject> deleteGOs = new List<GameObject>();
            //Console.WriteLine("HELLO" + this.Colliders.Count);
            foreach (Collider collider in this.Colliders)
            {
                collider.Update();


                //if (!collider.Stale)
                //{
                //    foreach (Collider subCollider in collider.CurColliders)
                //    {
                //        if (!collider.Intersects(subCollider))
                //        {
                //            collider.RemoveCurCollider(subCollider);
                //        }
                //    }

                //    foreach (Collider subCollider in this.Colliders)
                //    {
                //        if (collider.Intersects(subCollider))
                //        {
                //            collider.AddCurCollider(subCollider);
                //        }
                //    }
                //}
            }

            foreach (Collider c in this.removeFrom)
            {
                this.Colliders.Remove(c);
            }
            this.removeFrom.Clear();
            foreach (Collider c in this.toAdd)
            {
                this.Colliders.Add(c);
            }
            this.toAdd.Clear();
        }
    }
}
