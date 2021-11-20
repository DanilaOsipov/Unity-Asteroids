using Level.Config;
using Level.Other;

namespace Level.Model
{
    public class BigAsteroidPoolElementModel 
        : ObjectPoolElementModel<BigAsteroidPoolElementConfig>, IHealable
    {
        public int Health { get; set; }
        
        public BigAsteroidPoolElementModel(BigAsteroidPoolElementConfig config) : base(config)
        {
            Health = config.Health;
        }
    }
}