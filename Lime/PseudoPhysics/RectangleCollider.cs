using Microsoft.Xna.Framework;


namespace Lime.PseudoPhysics
{
    public class RectangleCollider : Collider
    {
        public RectangleCollider()
        {
        }
        internal override bool Intersects(Collider collider)
        {
            return base.Intersects(collider);
        }
    }
}
