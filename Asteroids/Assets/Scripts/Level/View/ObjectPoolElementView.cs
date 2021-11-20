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

        protected virtual void Awake()
        {
            gameObject.SetActive(false);
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