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
        
        public PlayerModel(PlayerConfig config) : base(config)
        {
        }
    }
}