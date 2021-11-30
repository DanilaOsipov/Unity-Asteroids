using System.Linq;
using Common;
using Level.Model;

namespace Level.Other
{
    public abstract class WeaponShootLogic
    {
        private readonly LevelModel _levelModel;
        
        public abstract WeaponType WeaponType { get; }

        protected WeaponShootLogic(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        public virtual void Execute()
        {
            var projectilePoolElementModel = GetProjectilePoolModel(_levelModel)
                .Elements.FirstOrDefault(x => !x.IsActive);
            if (projectilePoolElementModel == null) return;
            var weaponModel = _levelModel.PlayerModel.WeaponModels
                .FirstOrDefault(x => x.Config.Type == WeaponType);
            if (weaponModel == null) return;
            projectilePoolElementModel.Transform.position = weaponModel.Transform.position;
            projectilePoolElementModel.Transform.rotation = weaponModel.Transform.rotation;
            projectilePoolElementModel.IsActive = true;
            projectilePoolElementModel.CallUpdateMethod();
        }

        protected abstract IObjectPoolModel GetProjectilePoolModel(LevelModel levelModel);
    }
}