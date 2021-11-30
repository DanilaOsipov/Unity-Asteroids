using Level.Config;

namespace Level.Model
{
    public class LaserProjectilePoolModel : ObjectPoolModel<LaserProjectilePoolConfig,
        LaserProjectilePoolElementModel, LaserProjectilePoolElementConfig>
    {
        public LaserProjectilePoolModel(LaserProjectilePoolConfig config) : base(config)
        {
        }

        protected override LaserProjectilePoolElementModel 
            CreateElement(LaserProjectilePoolElementConfig elementConfig)
            => new LaserProjectilePoolElementModel(elementConfig);
    }
}