using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class EnemyPoolElementView : ObjectPoolElementView<EnemyPoolElementModel,
            EnemyPoolElementConfig>, IHittable
    {
        public override EntityType Type => EntityType.Enemy;
        
        public IHitListener HitListener { get; private set; }

        public override void Initialize(EnemyPoolElementModel data)
        {
            base.Initialize(data);
            HitListener = GetComponent<IHitListener>();
            HitListener.Initialize(Type, Id);
        }
    }
}