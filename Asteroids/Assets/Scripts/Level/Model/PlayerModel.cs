using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public class PlayerModel : Model<PlayerConfig>
    {
        public Transform Transform { get; set; }
        public Vector2 CurrentInputVector;
        public Vector2 CurrentVelocity;
        public bool CanShoot { get; set; } = true;
        
        public PlayerModel(PlayerConfig config) : base(config)
        {
        }
    }
}