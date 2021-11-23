using Level.Config;

namespace Level.Model
{
    public class EnemyPoolModel : ObjectPoolModel<EnemyPoolConfig, EnemyPoolElementModel, 
        EnemyPoolElementConfig>
    {
        public EnemyPoolModel(EnemyPoolConfig config) : base(config)
        {
        }

        protected override EnemyPoolElementModel CreateElement(EnemyPoolElementConfig elementConfig) 
            => new EnemyPoolElementModel(elementConfig);
    }
}