using System.Linq;
using Common;
using Level.Model;
using Level.Other;
using UI;
using UnityEngine;

namespace Level.Command
{
    public class AddHealthCommand : ICommand
    {
        private readonly LevelModel _levelModel;
        private readonly EntityType _entityType;
        private readonly string _elementId;
        private readonly int _health;

        public AddHealthCommand(LevelModel levelModel, EntityType entityType,
            string elementId, int health)
        {
            _levelModel = levelModel;
            _entityType = entityType;
            _elementId = elementId;
            _health = health;
        }

        public void Execute()
        {
            if (_entityType != EntityType.Player)
            {
                var objectPoolModel = _levelModel.ObjectPoolModels
                    .FirstOrDefault(x => x.ElementType == _entityType);
                var elementModel = objectPoolModel.Elements
                    .FirstOrDefault(x => x.Id == _elementId);
                if (elementModel is not IHealable healable) return;
                healable.Health += _health;
                if (healable.Health > 0) return;
                healable.Health = ((IHealable)elementModel.Config).Health;
                elementModel.IsActive = false;
                elementModel.CallUpdateMethod();

                if (elementModel.Type == EntityType.BigAsteroid)
                {
                    ReactOnBigAsteroidDestroy(elementModel);
                }
            }
            else
            {
                _levelModel.PlayerModel.Health += _health;
                _levelModel.PlayerModel.CallUpdateMethod();
                if (_levelModel.PlayerModel.Health > 0) return;
                _levelModel.IsUpdating = false;
                UIPanelsContainerView.Instance.HidePanel(UIPanelType.PlayerInfoPanel);
                UIPanelsContainerView.Instance.HidePanel(UIPanelType.ControlsTipsPanel);
                UIPanelsContainerView.Instance.ShowPanel(UIPanelType.GameOverPanel);
            }
        }

        private void ReactOnBigAsteroidDestroy(IObjectPoolElementModel bigAsteroidModel)
        {
            var smallAsteroidModels = _levelModel
                .ObjectPoolModels.FirstOrDefault(x
                    => x.ElementType == EntityType.SmallAsteroid)?.Elements;
            var asteroidsCount = 2;
            for (int i = 0; i < asteroidsCount; i++)
            {
                var asteroid = smallAsteroidModels
                    .FirstOrDefault(x => !x.IsActive);
                if (asteroid == null) continue;
                asteroid.IsActive = true;
                asteroid.Transform.position = bigAsteroidModel.Transform.position;
                asteroid.Transform.rotation = Quaternion
                    .Euler(new Vector3(0, 0, Random.Range(0, 360.0f)));
                asteroid.CallUpdateMethod();
            }
        }
    }
}