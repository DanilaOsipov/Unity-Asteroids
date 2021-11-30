using Level.Config;

namespace Level.Model
{
    public class LaserProjectilePoolElementModel 
        : ObjectPoolElementModel<LaserProjectilePoolElementConfig>
    {
        public LaserProjectilePoolElementModel(LaserProjectilePoolElementConfig config)
            : base(config)
        {
        }
    }
}