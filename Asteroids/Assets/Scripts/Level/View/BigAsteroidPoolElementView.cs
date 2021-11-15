using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BigAsteroidPoolElementView 
        : ObjectPoolElementView<BigAsteroidPoolElementModel, BigAsteroidPoolElementConfig>
    {
        public override EntityType Type => EntityType.BigAsteroid;
    }
}