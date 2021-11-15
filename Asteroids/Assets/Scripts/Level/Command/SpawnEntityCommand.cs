using System;
using System.Linq;
using Common;
using Level.Model;
using Level.Other;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Command
{
    public class SpawnEntityCommand : ICommand
    {
        private readonly EntityType _type;
        private readonly LevelModel _levelModel;

        public SpawnEntityCommand(EntityType type, LevelModel levelModel)
        {
            _type = type;
            _levelModel = levelModel;
        }
        
        public void Execute()
        {
            var objectPoolModel = _levelModel.ObjectPoolModels
                .FirstOrDefault(x => x.ElementType == _type);
            var elementModel = objectPoolModel.Elements
                .FirstOrDefault(x => !x.IsActive);
            var spawnerModel = _levelModel.SpawnerModels
                .FirstOrDefault(x => x.Config.Type == _type);
            var spawnPoint = spawnerModel.SpawnPoints[Random.Range(0,
                spawnerModel.SpawnPoints.Count)];
            elementModel.Transform.position = spawnPoint.position;
            // elementModel.Speed 
            elementModel.IsActive = true;
            elementModel.CallUpdateMethod();
        }
    }
}