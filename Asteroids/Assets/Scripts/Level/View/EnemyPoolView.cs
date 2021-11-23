using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class EnemyPoolView : ObjectPoolView<EnemyPoolModel, EnemyPoolConfig,
        EnemyPoolElementModel, EnemyPoolElementConfig>, IHittable
    {
        public override EntityType ElementType => EntityType.Enemy;
        public IHitListener HitListener { get; private set; }
        
        public override void Initialize(EnemyPoolModel data)
        {
            base.Initialize(data);
            HitListener = GetComponent<IHitListener>();
            HitListener.Initialize(ElementType, null);
        }
    }
}