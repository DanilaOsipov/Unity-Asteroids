using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class EnemyPoolElementView : ObjectPoolElementView<EnemyPoolElementModel,
            EnemyPoolElementConfig>
    {
        public override EntityType Type => EntityType.Enemy;
    }
}