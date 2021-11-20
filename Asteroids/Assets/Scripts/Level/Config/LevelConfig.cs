using System.Collections.Generic;
using Level.View;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
    public class LevelConfig : Common.Config
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private BulletPoolConfig _bulletPoolConfig;
        [SerializeField] private BigAsteroidPoolConfig _bigAsteroidPoolConfig;
        [SerializeField] private SmallAsteroidPoolConfig _smallAsteroidPoolConfig;
        [SerializeField] private List<SpawnerConfig> _spawnerConfigs;
        
        public PlayerConfig PlayerConfig => _playerConfig;

        public BulletPoolConfig BulletPoolConfig => _bulletPoolConfig;

        public BigAsteroidPoolConfig BigAsteroidPoolConfig => _bigAsteroidPoolConfig;

        public List<SpawnerConfig> SpawnerConfigs => _spawnerConfigs;

        public SmallAsteroidPoolConfig SmallAsteroidPoolConfig => _smallAsteroidPoolConfig;
    }
}