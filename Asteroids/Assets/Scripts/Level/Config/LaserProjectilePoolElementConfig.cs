using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "LaserProjectilePoolElementConfig",
        menuName = "Config/LaserProjectilePoolElementConfig")]
    public class LaserProjectilePoolElementConfig : ObjectPoolElementConfig, IDamagable
    {
        [SerializeField] private int _damage;

        public int Damage => _damage;
    }
}