using Level.Other;
using UnityEngine;

namespace Level.Config
{
    public abstract class ObjectPoolElementConfig : Common.Config, IDamagable
    {
        [SerializeField] private EntityType _type;
        [SerializeField] private string _viewPath;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private bool _isFriendlyToPlayer;

        public EntityType Type => _type;

        public string ViewPath => _viewPath;

        public float Speed => _speed;

        public int Damage => _damage;

        public bool IsFriendlyToPlayer => _isFriendlyToPlayer;
    }
}