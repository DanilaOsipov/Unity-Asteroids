using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BigAsteroidPoolElementView 
        : ObjectPoolElementView<BigAsteroidPoolElementModel, BigAsteroidPoolElementConfig>,
            IHittable
    {
        public override EntityType Type => EntityType.BigAsteroid;
        public IHitListener HitListener { get; private set; }

        public override void Initialize(BigAsteroidPoolElementModel data)
        {
            base.Initialize(data);
            HitListener = GetComponent<IHitListener>();
            HitListener.Initialize(Type, Id);
        }
    }
}