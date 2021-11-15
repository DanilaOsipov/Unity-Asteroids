using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "BigAsteroidPoolConfig", menuName = "Config/BigAsteroidPoolConfig")]
    public class BigAsteroidPoolConfig : ObjectPoolConfig<BigAsteroidPoolElementConfig>
    {
    }
}