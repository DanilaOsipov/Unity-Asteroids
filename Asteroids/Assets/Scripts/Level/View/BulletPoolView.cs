using Common;
using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BulletPoolView : ObjectPoolView<BulletPoolModel, BulletPoolConfig, BulletPoolElementModel,
        BulletPoolElementConfig, BulletPoolElementView>
    {
        public override ObjectPoolElementType ElementType => ObjectPoolElementType.Bullet;
    }
}