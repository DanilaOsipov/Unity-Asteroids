using System.Collections.Generic;
using Common;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public abstract class ObjectPoolModel<TConfig, TElementModel, TElementConfig> : Model<TConfig>, IObjectPool
        where TConfig : ObjectPoolConfig<TElementConfig>
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
    {
        public ObjectPoolElementType ElementType { get; }
        public List<TElementModel> Elements { get; }
        
        protected ObjectPoolModel(TConfig config) : base(config)
        {
            ElementType = config.ElementConfig.Type;
            Elements = new List<TElementModel>(config.InitialSize);
            for (int i = 0; i < config.InitialSize; i++)
            {
                var elementModel = CreateElement(config.ElementConfig);
                elementModel.Id = i.ToString();
                Elements.Add(elementModel);
            }
        }

        protected abstract TElementModel CreateElement(TElementConfig elementConfig);

        public void Add(IObjectPoolElement element)
        {
        }
    }
}