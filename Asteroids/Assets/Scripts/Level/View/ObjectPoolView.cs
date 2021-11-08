using System.Collections.Generic;
using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.View
{
    public abstract class ObjectPoolView<TModel, TConfig, TElementModel, TElementConfig, TElementView>
        : View<TModel>, IObjectPool
        where TModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
        where TElementView : ObjectPoolElementView<TElementModel, TElementConfig>
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
        where TConfig : ObjectPoolConfig
    {
        [SerializeField] private ObjectPoolElementType _elementType; 
        private List<TElementView> _elements;

        public ObjectPoolElementType ElementType => _elementType;
        public override void UpdateView(TModel data)
        {
            if (_elements == null)
            {
                _elements = new List<TElementView>(data.Config.InitialSize);
            }
        }
        
        public void Add(IObjectPoolElement element)
        {
            _elements.Add(element as TElementView);
        }
    }
}