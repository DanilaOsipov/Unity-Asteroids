﻿using System.Collections.Generic;
using System.Linq;
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
            foreach (var weaponModel in data.WeaponModels)
            {
                var weaponView = _weaponViews
                    .FirstOrDefault(x => x.Type == weaponModel.Config.Type);
                if (weaponView == null) continue;
                weaponModel.OnStateChanged 
                    += delegate(WeaponState state) { weaponView.ShowState(state); };
            }
        }
    }
}