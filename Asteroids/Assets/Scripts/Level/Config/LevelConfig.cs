using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
    public class LevelConfig : Common.Config
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public PlayerConfig PlayerConfig => _playerConfig;
    }
}