using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class SmallAsteroidPoolElementView 
        : ObjectPoolElementView<SmallAsteroidPoolElementModel, SmallAsteroidPoolElementConfig>
    {
        public override EntityType Type => EntityType.SmallAsteroid;
    }
}