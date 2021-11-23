using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "EnemyPoolConfig", menuName = "Config/EnemyPoolConfig")]
    public class EnemyPoolConfig : ObjectPoolConfig<EnemyPoolElementConfig>
    {
    }
}