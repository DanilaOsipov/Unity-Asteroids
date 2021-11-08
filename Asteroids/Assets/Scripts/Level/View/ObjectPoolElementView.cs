using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.View
{
    public abstract class ObjectPoolElementView<TModel, TConfig> : View<TModel>, IObjectPoolElement
        where TModel : ObjectPoolElementModel<TConfig>
        where TConfig : ObjectPoolElementConfig
    {
        public string Id { get; private set; }
        public ObjectPoolElementType Type { get; private set; }

        public override void UpdateView(TModel data)
        {
            gameObject.SetActive(data.IsActive);
        }

        public void Initialize(TModel data)
        {
            Id = data.Id;
            Type = data.Type;
        }
    }
}