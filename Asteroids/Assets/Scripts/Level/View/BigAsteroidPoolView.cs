using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BigAsteroidPoolView : ObjectPoolView<BigAsteroidPoolModel, BigAsteroidPoolConfig, BigAsteroidPoolElementModel, BigAsteroidPoolElementConfig>
    {
        public override EntityType ElementType => EntityType.BigAsteroid;
    }
}