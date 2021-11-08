using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace ResourceManagement
{
    public abstract class LoadObjectPoolElementViewCommand<TElementModel, TElementConfig> : ICommand
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
    {
        private readonly IObjectPool _objectPool;
        private readonly TElementModel _elementModel;

        protected LoadObjectPoolElementViewCommand(IObjectPool objectPool, TElementModel elementModel)
        {
            _objectPool = objectPool;
            _elementModel = elementModel;
        }
        
        public void Execute()
        {
            var prefab = Resources.Load(_elementModel.Config.ViewPath);
            var instance = Object.Instantiate(prefab) as IObjectPoolElement;
            _objectPool.Add(instance);
        }
    }
}