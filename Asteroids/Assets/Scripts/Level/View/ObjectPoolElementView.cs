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
        public abstract ObjectPoolElementType Type { get; }
        public Transform Transform => transform;

        private void Awake()
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
    }
}