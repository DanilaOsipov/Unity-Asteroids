using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public abstract class ObjectPoolModel<TConfig, TElementModel, TElementConfig> 
        : Model<TConfig>, IObjectPoolModel
        where TConfig : ObjectPoolConfig<TElementConfig>
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
    {
        public ObjectPoolElementType ElementType { get; }

        public List<IObjectPoolElementModel> Elements { get; }
        
        protected ObjectPoolModel(TConfig config) : base(config)
        {
            ElementType = config.ElementConfig.Type;
            Elements = new List<IObjectPoolElementModel>(config.InitialSize);
            for (int i = 0; i < config.InitialSize; i++)
            {
                var elementModel = CreateElement(config.ElementConfig);
                elementModel.Id = i.ToString();
                elementModel.OnUpdate += CallUpdateMethod;
                Elements.Add(elementModel);
            }
        }

        protected abstract TElementModel CreateElement(TElementConfig elementConfig);

        public void Add(IObjectPoolElementModel element)
        {
        }
        
        public void SetElementActive(string id, bool isActive)
        {
            var elementModel = Elements.FirstOrDefault(x => x.Id == id);
            if (elementModel != null)
            {
                elementModel.IsActive = isActive;
                CallUpdateMethod();
            }
        }
    }
}