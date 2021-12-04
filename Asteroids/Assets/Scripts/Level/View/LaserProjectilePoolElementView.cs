using System;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.View
{
    [RequireComponent(typeof(TrailRenderer))]
    public class LaserProjectilePoolElementView
        : ObjectPoolElementView<LaserProjectilePoolElementModel, 
            LaserProjectilePoolElementConfig>
    {
        private TrailRenderer _trailRenderer;
        
        public override EntityType Type => EntityType.LaserProjectile;

        protected override void Awake()
        {
            base.Awake();
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            _trailRenderer.Clear();
        }
    }
}