using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class SmallAsteroidPoolView : ObjectPoolView<SmallAsteroidPoolModel, SmallAsteroidPoolConfig,
        SmallAsteroidPoolElementModel, SmallAsteroidPoolElementConfig>
    {
        public override EntityType ElementType => EntityType.SmallAsteroid;
    }
}