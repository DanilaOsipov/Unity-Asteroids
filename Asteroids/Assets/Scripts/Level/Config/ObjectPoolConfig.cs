using Common;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    // TODO GENERIC
    public abstract class ObjectPoolConfig : Common.Config
    {
        [SerializeField] private int _initialSize = 20;
        [SerializeField] private ObjectPoolElementConfig _elementConfig;
        public int InitialSize => _initialSize;

        public ObjectPoolElementConfig ElementConfig => _elementConfig;
    }
}