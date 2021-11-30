using System;
using UnityEngine;

namespace Level.Other
{
    public interface ICollidable
    {
        public event Action<EntityType, string, Collision2D> OnCollisionEnter;
    }
}