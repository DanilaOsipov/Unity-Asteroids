using Common;
using Level.Model;

namespace Level.Other
{
    public class BulletGunShootLogic : WeaponShootLogic
    {
        public override WeaponType WeaponType => WeaponType.BulletGun;

        public BulletGunShootLogic(LevelModel levelModel) : base(levelModel)
        {
        }
        
        protected override IObjectPoolModel GetProjectilePoolModel(LevelModel levelModel)
            => levelModel.BulletPoolModel;
    }
}