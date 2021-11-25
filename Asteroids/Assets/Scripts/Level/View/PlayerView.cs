using System.Collections.Generic;
using Common;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class PlayerView : View<PlayerModel>
    {
        [SerializeField] private List<WeaponView> _weaponViews;

        public List<WeaponView> WeaponViews => _weaponViews;

        public override void UpdateView(PlayerModel data)
        {
        }

        public override void Initialize(PlayerModel data)
        {
        }
    }
}