using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "EnemyPoolElementConfig",
        menuName = "Config/EnemyPoolElementConfig")]
    public class EnemyPoolElementConfig : ObjectPoolElementConfig, IHealable
    {
        [SerializeField] private int _health;

        public int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}