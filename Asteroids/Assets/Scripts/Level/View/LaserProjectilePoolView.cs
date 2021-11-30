using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class LaserProjectilePoolView : ObjectPoolView<LaserProjectilePoolModel, 
        LaserProjectilePoolConfig, LaserProjectilePoolElementModel,
        LaserProjectilePoolElementConfig>
    {
        public override EntityType ElementType => EntityType.LaserProjectile;
    }
}