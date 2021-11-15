using System.Collections.Generic;
using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public class SpawnerModel : Model<SpawnerConfig>
    {
        public List<Transform> SpawnPoints { get; set; }
        
        public SpawnerModel(SpawnerConfig config) : base(config)
        {
        }
    }
}