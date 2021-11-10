using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using ResourceManagement;
using UnityEngine;

namespace Level.View
{
    public abstract class ObjectPoolView<TModel, TConfig, TElementModel, TElementConfig, TElementView>
        : View<TModel>, IObjectPool
        where TModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
        where TElementView : ObjectPoolElementView<TElementModel, TElementConfig>
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
        where TConfig : ObjectPoolConfig<TElementConfig>
    {
        private List<TElementView> _elements;

        public abstract ObjectPoolElementType ElementType { get; }

        public List<TElementView> Elements => _elements;

        public override void UpdateView(TModel data)
        {
            if (_elements == null)
            {
                _elements = new List<TElementView>(data.Config.InitialSize);
                foreach (var loadObjectPoolElementViewCommand in data.Elements
                    .Select(element => new LoadObjectPoolElementCommand(this, element.Config, element.Id)))
                {
                    loadObjectPoolElementViewCommand.Execute();
                }
            }
            foreach (var elementView in _elements)
            { 
                elementView.UpdateView(data.Elements.FirstOrDefault(x => x.Id == elementView.Id));   
            }
        }

        public void Add(IObjectPoolElement element)
        {
            var objectPoolElementView = element as TElementView;
            objectPoolElementView.transform.SetParent(transform);
            objectPoolElementView.transform.localScale = transform.localScale; ;
            _elements.Add(objectPoolElementView);
        }
    }
}