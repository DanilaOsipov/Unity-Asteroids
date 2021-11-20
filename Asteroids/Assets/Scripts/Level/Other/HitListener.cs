using System;
using UnityEngine;

namespace Level.Other
{
    public class HitListener : MonoBehaviour, IHitListener
    {
        private EntityType _type;
        private string _id;

        public event Action<EntityType, string, int> OnHit
            = delegate(EntityType type, string damage, int id) { };
        
        public void Initialize(EntityType entityType, string id)
        {
            _type = entityType;
            _id = id;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagable = other.transform.GetComponent<IDamagable>();
            if (damagable == null) return;
            OnHit(_type, _id, damagable.Damage);
            other.gameObject.SetActive(false);
        }
    }
}