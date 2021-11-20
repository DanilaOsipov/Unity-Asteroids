using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class SmallAsteroidPoolView : ObjectPoolView<SmallAsteroidPoolModel, SmallAsteroidPoolConfig,
        SmallAsteroidPoolElementModel, SmallAsteroidPoolElementConfig>, IHittable
    {
        public override EntityType ElementType => EntityType.SmallAsteroid;
        public IHitListener HitListener { get; private set; }
        
        public override void Initialize(SmallAsteroidPoolModel data)
        {
            base.Initialize(data);
            HitListener = GetComponent<IHitListener>();
            HitListener.Initialize(ElementType, null);
        }
    }
}