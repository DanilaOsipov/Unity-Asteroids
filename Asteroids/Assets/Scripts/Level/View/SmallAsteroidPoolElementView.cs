using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class SmallAsteroidPoolElementView 
        : ObjectPoolElementView<SmallAsteroidPoolElementModel, SmallAsteroidPoolElementConfig>,
        IHittable
    {
        public override EntityType Type => EntityType.SmallAsteroid;
        public IHitListener HitListener { get; private set; }

        public override void Initialize(SmallAsteroidPoolElementModel data)
        {
            base.Initialize(data);
            HitListener = GetComponent<IHitListener>();
            HitListener.Initialize(Type, Id);
        }
        
    }
}