using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BigAsteroidPoolView : ObjectPoolView<BigAsteroidPoolModel, BigAsteroidPoolConfig,
        BigAsteroidPoolElementModel, BigAsteroidPoolElementConfig>, IHittable
    {
        public override EntityType ElementType => EntityType.BigAsteroid;
        public IHitListener HitListener { get; private set; }

        public override void Initialize(BigAsteroidPoolModel data)
        {
            base.Initialize(data);
            HitListener = GetComponent<IHitListener>();
            HitListener.Initialize(ElementType, null);
        }
    }
}