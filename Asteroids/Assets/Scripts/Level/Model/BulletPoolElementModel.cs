using Level.Config;

namespace Level.Model
{
    public class BulletPoolElementModel : ObjectPoolElementModel<BulletPoolElementConfig>
    {
        public BulletPoolElementModel(BulletPoolElementConfig config) : base(config)
        {
        }
    }
}