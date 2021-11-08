using System.Collections.Generic;
using Common;
using Level.Config;
using Level.Other;

namespace Level.Model
{
    public abstract class ObjectPoolModel<TConfig, TElementModel, TElementConfig> : Model<TConfig>, IObjectPool
        where TConfig : ObjectPoolConfig
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
                Elements[i] = CreateElement(config.ElementConfig as TElementConfig);
                Elements[i].Id = i.ToString();
            }
        }

        protected abstract TElementModel CreateElement(TElementConfig elementConfig);

        public void Add(IObjectPoolElement element)
        {
        }
    }
}