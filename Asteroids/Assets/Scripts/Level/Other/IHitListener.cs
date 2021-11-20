using System;

namespace Level.Other
{
    public interface IHitListener
    {
        event Action<EntityType, string, int> OnHit;
        void Initialize(EntityType entityType, string id);
    }
}