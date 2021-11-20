using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "SmallAsteroidPoolConfig",
        menuName = "Config/SmallAsteroidPoolConfig")]
    public class SmallAsteroidPoolConfig : ObjectPoolConfig<SmallAsteroidPoolElementConfig>
    {
        
    }
}