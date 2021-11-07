using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public class PlayerModel : Model<PlayerConfig>
    {
        public Transform Transform { get; private set; }
        
        public PlayerModel(PlayerConfig config) : base(config)
        {
        }

        public void SetTransform(Transform transform)
        {
            Transform = transform;
        }
    }
}