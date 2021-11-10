using System.Linq;
using System.Threading.Tasks;
using Common;
using Level.Model;
using UnityEngine;

namespace Level.Command
{
    public class ShootCommand : ICommand
    {
        private readonly PlayerModel _playerModel;
        private readonly BulletPoolModel _bulletPoolModel;

        public ShootCommand(PlayerModel playerModel, BulletPoolModel bulletPoolModel)
        {
            _playerModel = playerModel;
            _bulletPoolModel = bulletPoolModel;
        }
        
        public async void Execute()
        {
            if (!_playerModel.CanShoot) return;
            var bulletPoolElementModel = _bulletPoolModel
                .Elements.FirstOrDefault(x => !x.IsActive);
            if (bulletPoolElementModel != null)
            {
                bulletPoolElementModel.Transform.position = _playerModel.Transform.position;
                bulletPoolElementModel.Transform.rotation = _playerModel.Transform.rotation;
                bulletPoolElementModel.Speed = _playerModel.Config.BulletSpeed;
                bulletPoolElementModel.IsActive = true;
                bulletPoolElementModel.CallUpdateMethod();
                _playerModel.CanShoot = false;
                await Task.Delay((int)(_playerModel.Config.ShootDelay * 1000.0f));
                _playerModel.CanShoot = true;
            }
        }
    }
}