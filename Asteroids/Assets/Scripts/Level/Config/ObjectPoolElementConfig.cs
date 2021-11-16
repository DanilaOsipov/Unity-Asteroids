using Level.Other;
using UnityEngine;

namespace Level.Config
{
    public abstract class ObjectPoolElementConfig : Common.Config
    {
        [SerializeField] private EntityType _type;
        [SerializeField] private string _viewPath;
        [SerializeField] private float _speed;

        public EntityType Type => _type;

        public string ViewPath => _viewPath;

        public float Speed => _speed;
    }
}