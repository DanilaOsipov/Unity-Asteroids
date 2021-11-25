using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public class WeaponModel : Model<WeaponConfig>
    {
        public Transform Transform { get; set; }
        public bool CanShoot { get; set; } = true;
        
        public WeaponModel(WeaponConfig config) : base(config)
        {
        }
    }
}