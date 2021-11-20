using Level.Config;
using Level.Model;
using Level.Other;

namespace Level.View
{
    public class BulletPoolElementView 
        : ObjectPoolElementView<BulletPoolElementModel, BulletPoolElementConfig>, IDamagable
    {
        public override EntityType Type => EntityType.Bullet;
        public int Damage { get; private set; }

        public override void UpdateView(BulletPoolElementModel data)
        {
            base.UpdateView(data);
            Damage = data.Config.Damage;
        }
    }
}