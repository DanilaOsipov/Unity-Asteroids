using System;
using UnityEngine;

namespace Level.Other
{
    public class ChildsHitListener : MonoBehaviour, IHitListener
    {
        public event Action<EntityType, string, int> OnHit 
            = delegate(EntityType type, string damage, int id) { };
        
        public void Initialize(EntityType entityType, string id)
        {
            foreach (var hittable in GetComponentsInChildren<IHittable>(true))
            {
                if (hittable.HitListener == this) continue;
                hittable.HitListener.OnHit += (type, childId, damage) =>
                    { OnHit(type, childId, damage); };
            }
        }
    }
}