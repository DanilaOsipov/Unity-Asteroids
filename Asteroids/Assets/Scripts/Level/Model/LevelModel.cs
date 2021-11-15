using System.Collections.Generic;
using System.Linq;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public class LevelModel : Common.Model<LevelConfig>
    {
        public PlayerModel PlayerModel { get; }
        public BulletPoolModel BulletPoolModel { get; }
        public BigAsteroidPoolModel BigAsteroidPoolModel { get; }
        public List<IObjectPoolModel> ObjectPoolModels { get; } = new List<IObjectPoolModel>();
        public BoxCollider2D BoxCollider2D { get; set; }
        public List<SpawnerModel> SpawnerModels { get; } = new List<SpawnerModel>();

        public LevelModel(LevelConfig config) : base(config)
        {
            PlayerModel = new PlayerModel(config.PlayerConfig);
            BulletPoolModel = new BulletPoolModel(config.BulletPoolConfig);
            BigAsteroidPoolModel = new BigAsteroidPoolModel(config.BigAsteroidPoolConfig);
            ObjectPoolModels.Add(BulletPoolModel);
            ObjectPoolModels.Add(BigAsteroidPoolModel);
            foreach (var spawnerModel in config.SpawnerConfigs
                .Select(spawnerConfig => new SpawnerModel(spawnerConfig)))
            {
                SpawnerModels.Add(spawnerModel);
            }
        }
    }
}