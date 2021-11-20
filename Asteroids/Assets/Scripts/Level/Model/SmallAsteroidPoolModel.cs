using Level.Config;

namespace Level.Model
{
    public class SmallAsteroidPoolModel : ObjectPoolModel<SmallAsteroidPoolConfig,
        SmallAsteroidPoolElementModel, SmallAsteroidPoolElementConfig>
    {
        public SmallAsteroidPoolModel(SmallAsteroidPoolConfig config) : base(config)
        {
        }

        protected override SmallAsteroidPoolElementModel 
            CreateElement(SmallAsteroidPoolElementConfig elementConfig)
            => new SmallAsteroidPoolElementModel(elementConfig);
    }
}