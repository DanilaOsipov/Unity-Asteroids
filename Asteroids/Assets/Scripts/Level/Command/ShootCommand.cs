using System.Linq;
using System.Threading.Tasks;
using Common;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Command
{
    public class ShootCommand : ICommand
    {
        private readonly WeaponType _weaponType;
        private readonly LevelModel _levelModel;
        
        public ShootCommand(WeaponType weaponType, LevelModel levelModel)
        {
            _weaponType = weaponType;
            _levelModel = levelModel;
        }
        
        public async void Execute()
        {
            var weaponModel = _levelModel.PlayerModel.WeaponModels
                .FirstOrDefault(x => x.Config.Type == _weaponType);
            if (weaponModel == null) return;
            if (weaponModel.State != WeaponState.ReadyToShoot) return;
            if (weaponModel.State == WeaponState.Reloading) return;
            weaponModel.State = WeaponState.Shooting;
            ExecuteShootLogic();
            if (weaponModel.Config.IsReloadable 
                && weaponModel.FiredShotsCount % weaponModel.Config.ShotsBeforeReload == 0)
            {
                weaponModel.State = WeaponState.Reloading;
                await Task.Delay(Mathf.RoundToInt(weaponModel.Config.ReloadTime * 1000.0f));
            }
            else
            {
                weaponModel.State = WeaponState.DelayingAfterShot;
                await Task.Delay(Mathf.RoundToInt(weaponModel.Config.DelayAfterShot * 1000.0f));
            }
            weaponModel.State = WeaponState.ReadyToShoot;
        }

        private void ExecuteShootLogic()
        {
            WeaponShootLogic weaponShootLogic = _weaponType switch
            {
                WeaponType.BulletGun => new BulletGunShootLogic(_levelModel),
                WeaponType.LaserGun => new LaserGunShootLogic(_levelModel),
                _ => null
            };
            weaponShootLogic?.Execute();
        }
    }
}