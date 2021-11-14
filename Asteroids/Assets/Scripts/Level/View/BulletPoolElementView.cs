using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BulletPoolElementView 
        : ObjectPoolElementView<BulletPoolElementModel, BulletPoolElementConfig>
    {
        public override ObjectPoolElementType Type => ObjectPoolElementType.Bullet;
    }
}