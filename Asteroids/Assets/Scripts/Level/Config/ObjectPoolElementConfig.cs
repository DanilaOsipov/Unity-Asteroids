using Level.Other;
using UnityEngine;

namespace Level.Config
{
    public abstract class ObjectPoolElementConfig : Common.Config
    {
        [SerializeField] private ObjectPoolElementType _type;
        [SerializeField] private string _viewPath;

        public ObjectPoolElementType Type => _type;

        public string ViewPath => _viewPath;
    }
}