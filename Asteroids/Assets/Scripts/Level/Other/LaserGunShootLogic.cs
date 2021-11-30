using Common;
using Level.Model;

namespace Level.Other
{
    public class LaserGunShootLogic : WeaponShootLogic
    {
        public override WeaponType WeaponType => WeaponType.LaserGun;
        
        public LaserGunShootLogic(LevelModel levelModel) : base(levelModel)
        {
        }
        
        protected override IObjectPoolModel GetProjectilePoolModel(LevelModel levelModel)
            => levelModel.LaserProjectilePoolModel;
    }
}