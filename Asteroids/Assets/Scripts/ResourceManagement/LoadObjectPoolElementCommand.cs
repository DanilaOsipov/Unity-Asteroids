﻿using Common;
using Level.Config;
using Level.Other;
using Unity.VisualScripting;
using UnityEngine;

namespace ResourceManagement
{
    public class LoadObjectPoolElementCommand : ICommand
    {
        private readonly IObjectPool _objectPool;
        private readonly ObjectPoolElementConfig  _elementConfig;
        private readonly string _elementId;

        public LoadObjectPoolElementCommand(IObjectPool objectPool,
            ObjectPoolElementConfig elementConfig, string elementId)
        {
            _objectPool = objectPool;
            _elementConfig = elementConfig;
            _elementId = elementId;
        }
        
        public void Execute()
        {
            var prefab = Resources.Load(_elementConfig.ViewPath);
            var instance = Object.Instantiate(prefab);
            var poolElement = instance.GetComponent<IObjectPoolElement>();
            poolElement.Id = _elementId;
            _objectPool.Add(poolElement);
        }
    }
}