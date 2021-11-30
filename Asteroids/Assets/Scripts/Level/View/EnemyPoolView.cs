using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class EnemyPoolView : ObjectPoolView<EnemyPoolModel, EnemyPoolConfig,
        EnemyPoolElementModel, EnemyPoolElementConfig>
    {
        public override EntityType ElementType => EntityType.Enemy;
    }
}