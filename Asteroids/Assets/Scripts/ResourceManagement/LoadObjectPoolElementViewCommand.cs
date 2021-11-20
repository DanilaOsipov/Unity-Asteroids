using Common;
using Level.Config;
using Level.Other;
using Unity.VisualScripting;
using UnityEngine;

namespace ResourceManagement
{
    public class LoadObjectPoolElementViewCommand : ICommand
    {
        private readonly IObjectPoolView _objectPool;
        private readonly IObjectPoolElementModel _elementModel;

        public LoadObjectPoolElementViewCommand(IObjectPoolView objectPool,
            IObjectPoolElementModel elementModel)
        {
            _objectPool = objectPool;
            _elementModel = elementModel;
        }
        
        public void Execute()
        {
            var prefab = Resources.Load(_elementModel.Config.ViewPath);
            var instance = Object.Instantiate(prefab);
            var poolElement = instance.GetComponent<IObjectPoolElementView>();
            poolElement.Initialize(_elementModel);
            _objectPool.Add(poolElement);
        }
    }
}