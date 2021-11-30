using System;
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

        public abstract EntityType ElementType { get; }

        public List<IObjectPoolElementView> Elements => _elements;
        
        public event Action<EntityType, string, Collision2D> OnCollisionEnter
            = delegate(EntityType type, string id, Collision2D collision) { };
        
        public override void UpdateView(TModel data)
        {
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

        public override void Initialize(TModel data)
        {
            _elements = new List<IObjectPoolElementView>(data.Config.InitialSize);
            foreach (var loadObjectPoolElementViewCommand in data.Elements
                .Select(element => new LoadObjectPoolElementViewCommand(this, element)))
            {
                loadObjectPoolElementViewCommand.Execute();
            }
        }

        void IObjectPoolView.Initialize(IObjectPoolModel objectPoolModel)
        {
            Initialize(objectPoolModel as TModel);
        }

        public void Add(IObjectPoolElementView element)
        {
            element.Transform.SetParent(transform);
            element.Transform.localScale = transform.localScale; 
            element.OnCollisionEnter += delegate(EntityType type, string id,
                Collision2D collision) { OnCollisionEnter(type, id, collision); };
            _elements.Add(element);
        }
    }
}