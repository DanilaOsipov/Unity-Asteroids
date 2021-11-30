using System;
using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.View
{
    public abstract class ObjectPoolElementView<TModel, TConfig> 
        : View<TModel>, IObjectPoolElementView
        where TModel : ObjectPoolElementModel<TConfig>
        where TConfig : ObjectPoolElementConfig
    {
        public string Id { get; set; }
        
        public abstract EntityType Type { get; }
        
        public Transform Transform => transform;
        
        public event Action<EntityType, string, Collision2D> OnCollisionEnter 
            = delegate(EntityType type, string id, Collision2D collision) { };

        protected virtual void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter(Type, Id, other);
        }

        public override void UpdateView(TModel data)
        {
            gameObject.SetActive(data.IsActive);
        }

        void IObjectPoolElementView.UpdateView(IObjectPoolElementModel data)
        {
            UpdateView(data as TModel);
        }

        void IObjectPoolElementView.Initialize(IObjectPoolElementModel elementModel)
        {
            Initialize(elementModel as TModel);
        }

        public override void Initialize(TModel data)
        {
            Id = data.Id;
        }
    }
}