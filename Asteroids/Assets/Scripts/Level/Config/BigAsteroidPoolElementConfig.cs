using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "BigAsteroidPoolElementConfig",
        menuName = "Config/BigAsteroidPoolElementConfig")]
    public class BigAsteroidPoolElementConfig : ObjectPoolElementConfig, IHealable
    {
        [SerializeField] private int _health = 1;

        public int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}