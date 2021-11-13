using System.Collections.Generic;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public class LevelModel : Common.Model<LevelConfig>
    {
        public PlayerModel PlayerModel { get; }
        public BulletPoolModel BulletPoolModel { get; }
        public List<IObjectPoolModel> ObjectPoolModels { get; } = new List<IObjectPoolModel>();
        public BoxCollider2D BoxCollider2D { get; set; }

        public LevelModel(LevelConfig config) : base(config)
        {
            PlayerModel = new PlayerModel(config.PlayerConfig);
            BulletPoolModel = new BulletPoolModel(config.BulletPoolConfig);
            ObjectPoolModels.Add(BulletPoolModel);
        }
    }
}