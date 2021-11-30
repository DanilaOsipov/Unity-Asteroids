using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "LaserProjectilePoolConfig", 
        menuName = "Config/LaserProjectilePoolConfig")]
    public class LaserProjectilePoolConfig  : ObjectPoolConfig<LaserProjectilePoolElementConfig>
    {
    }
}