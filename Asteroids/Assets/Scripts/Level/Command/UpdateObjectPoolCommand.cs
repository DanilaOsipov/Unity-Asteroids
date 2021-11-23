using System.Linq;
using Common;
using Level.Model;
using Level.Other;
using Level.View;
using UnityEngine;

namespace Level.Command
{
    public class UpdateObjectPoolCommand : ICommand
    {
        private readonly LevelModel _levelModel;
        private readonly EntityType _entityType;

        public UpdateObjectPoolCommand(LevelModel levelModel, EntityType entityType)
        {
            _levelModel = levelModel;
            _entityType = entityType;
        }

        public void Execute()
        {
            var objectPoolModel = _levelModel.ObjectPoolModels
                .FirstOrDefault(x => x.ElementType == _entityType);
            foreach (var elementModel in objectPoolModel.Elements
                .Where(elementModel => elementModel.IsActive))
            {
                if (elementModel.Type == EntityType.Enemy)
                {
                    elementModel.Transform.up = _levelModel.PlayerModel.Transform.position
                                                - elementModel.Transform.position;
                }
                elementModel.Transform.position += elementModel.Transform
                    .up * (elementModel.Speed * Time.deltaTime);
            }
        }
    }
}