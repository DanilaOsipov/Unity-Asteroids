using Level.Config;
using Level.Other;

namespace Level.Model
{
    public class EnemyPoolElementModel
        : ObjectPoolElementModel<EnemyPoolElementConfig>, IHealable
    {
        public int Health { get; set; }
        
        public EnemyPoolElementModel(EnemyPoolElementConfig config) : base(config)
        {
            Health = config.Health;
        }
    }
}