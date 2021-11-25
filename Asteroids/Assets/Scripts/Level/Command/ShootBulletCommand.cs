using System.Linq;
using System.Threading.Tasks;
using Common;
using Level.Model;
using UnityEngine;

namespace Level.Command
{
    public class ShootBulletCommand : ICommand
    {
        private readonly PlayerModel _playerModel;
        private readonly BulletPoolModel _bulletPoolModel;

        public ShootBulletCommand(PlayerModel playerModel, BulletPoolModel bulletPoolModel)
        {
            _playerModel = playerModel;
            _bulletPoolModel = bulletPoolModel;
        }
        
        public async void Execute()
        {
            var weaponModel = _playerModel.WeaponModels
                .FirstOrDefault(x => x.Config.Type == WeaponType.BulletGun);
            if (weaponModel == null) return;
            if (!weaponModel.CanShoot) return;
            var bulletPoolElementModel = _bulletPoolModel
                .Elements.FirstOrDefault(x => !x.IsActive);
            if (bulletPoolElementModel == null) return;
            bulletPoolElementModel.Transform.position = weaponModel.Transform.position;
            bulletPoolElementModel.Transform.rotation = weaponModel.Transform.rotation;
            bulletPoolElementModel.IsActive = true;
            bulletPoolElementModel.CallUpdateMethod();
            weaponModel.CanShoot = false;
            await Task.Delay((int)(weaponModel.Config.ShootDelay * 1000.0f));
            weaponModel.CanShoot = true;
        }
    }
}