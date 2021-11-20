using Level.Config;
using Level.Other;

namespace Level.Model
{
    public class SmallAsteroidPoolElementModel
        : ObjectPoolElementModel<SmallAsteroidPoolElementConfig>, IHealable
    {
        public int Health { get; set; }

        public SmallAsteroidPoolElementModel(SmallAsteroidPoolElementConfig config) : base(config)
        {
            Health = config.Health;
        }
    }
}