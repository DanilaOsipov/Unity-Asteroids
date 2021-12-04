using System.Collections.Generic;
using Common;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public class PlayerModel : Model<PlayerConfig>, IHealable
    {
        public Transform Transform { get; set; }
        public Vector2 CurrentInputVector;
        public Vector2 CurrentVelocity;
        public List<WeaponModel> WeaponModels { get; } = new List<WeaponModel>();
        public int Health { get; set; }
        
        public PlayerModel(PlayerConfig config) : base(config)
        {
            Health = config.Health;
            foreach (var weaponConfig in config.WeaponConfigs)
            {
                WeaponModels.Add(new WeaponModel(weaponConfig));
            }
        }
    }
}