using Common;
using Level.Config;

namespace Level.Model
{
    public class BulletPoolModel : ObjectPoolModel<BulletPoolConfig, BulletPoolElementModel, BulletPoolElementConfig>
    {
        public BulletPoolModel(BulletPoolConfig config) : base(config)
        {
        }

        protected override BulletPoolElementModel CreateElement(BulletPoolElementConfig elementConfig) =>
            new(elementConfig);
    }
}