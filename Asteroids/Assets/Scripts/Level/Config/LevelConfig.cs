using Level.View;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
    public class LevelConfig : Common.Config
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private BulletPoolConfig _bulletPoolConfig;
        
        public PlayerConfig PlayerConfig => _playerConfig;

        public BulletPoolConfig BulletPoolConfig => _bulletPoolConfig;
    }
}