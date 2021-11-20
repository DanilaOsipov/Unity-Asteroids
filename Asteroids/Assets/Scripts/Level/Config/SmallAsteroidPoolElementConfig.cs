using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "SmallAsteroidPoolElementConfig",
        menuName = "Config/SmallAsteroidPoolElementConfig")]
    public class SmallAsteroidPoolElementConfig : ObjectPoolElementConfig, IHealable
    {
        [SerializeField] private int _health = 1;

        public int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}