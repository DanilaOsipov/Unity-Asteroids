using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "BulletPoolElementConfig", menuName = "Config/BulletPoolElementConfig")]
    public class BulletPoolElementConfig : ObjectPoolElementConfig, IDamagable
    {
        [SerializeField] private int _damage;

        public int Damage => _damage;
    }
}