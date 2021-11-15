using Level.Other;
using UnityEngine;

namespace Level.Config
{
    public abstract class ObjectPoolElementConfig : Common.Config
    {
        [SerializeField] private EntityType _type;
        [SerializeField] private string _viewPath;

        public EntityType Type => _type;

        public string ViewPath => _viewPath;
    }
}