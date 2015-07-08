using Microsoft.Xna.Framework;


namespace Lime.PseudoPhysics
{
    public class RectangleCollider : Collider
    {
        public RectangleCollider(GameObject gameObject)
        {
            gameObject.AddComponent(this);
            this.LastPosition = this.GameObject.Transform.Position;
        }
        internal override bool Intersects(Collider collider)
        {
            return base.Intersects(collider);
        }
    }
}
