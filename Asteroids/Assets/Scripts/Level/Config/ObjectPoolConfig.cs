using Common;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    public abstract class ObjectPoolConfig<TElementConfig> : Common.Config
    where TElementConfig : ObjectPoolElementConfig
    {
        [SerializeField] private int _initialSize = 20;
        [SerializeField] private TElementConfig  _elementConfig;
        public int InitialSize => _initialSize;

        public TElementConfig  ElementConfig => _elementConfig;
    }
}