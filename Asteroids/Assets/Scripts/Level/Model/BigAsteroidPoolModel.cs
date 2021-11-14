using Level.Config;

namespace Level.Model
{
    public class BigAsteroidPoolModel : ObjectPoolModel<BigAsteroidPoolConfig, BigAsteroidPoolElementModel, 
        BigAsteroidPoolElementConfig>
    {
        public BigAsteroidPoolModel(BigAsteroidPoolConfig config) : base(config)
        {
        }

        protected override BigAsteroidPoolElementModel CreateElement(BigAsteroidPoolElementConfig elementConfig)
            => new BigAsteroidPoolElementModel(elementConfig);
    }
}