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
    public abstract class ObjectPoolView<TModel, TConfig, TElementModel, TElementConfig>
        : View<TModel>, IObjectPoolView
        where TModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
        where TConfig : ObjectPoolConfig<TElementConfig>
    {
        private List<IObjectPoolElementView> _elements;

        public abstract ObjectPoolElementType ElementType { get; }

        public List<IObjectPoolElementView> Elements => _elements;

        public override void UpdateView(TModel data)
        {
            if (_elements == null)
            {
                _elements = new List<IObjectPoolElementView>(data.Config.InitialSize);
                foreach (var loadObjectPoolElementViewCommand in data.Elements
                    .Select(element => new LoadObjectPoolElementViewCommand(this, element.Config, element.Id)))
                {
                    loadObjectPoolElementViewCommand.Execute();
                }
            }
            foreach (var elementView in _elements)
            { 
                elementView.UpdateView(data.Elements
                    .FirstOrDefault(x => x.Id == elementView.Id));   
            }
        }

        void IObjectPoolView.UpdateView(IObjectPoolModel objectPoolModel)
        {
            UpdateView(objectPoolModel as TModel);
        }

        public void Add(IObjectPoolElementView element)
        {
            element.Transform.SetParent(transform);
            element.Transform.localScale = transform.localScale; ;
            _elements.Add(element);
        }
    }
}