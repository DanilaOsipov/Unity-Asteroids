using Level.Other;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Config/SpawnerConfig")]
    public class SpawnerConfig : Common.Config
    {
        [SerializeField] private EntityType _entityType;
        [SerializeField] private float _spawnDelay = 3.0f;

        public EntityType Type => _entityType;

        public float SpawnDelay => _spawnDelay;
    }
}