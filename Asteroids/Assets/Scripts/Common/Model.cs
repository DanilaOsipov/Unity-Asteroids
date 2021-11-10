using System;

namespace Common
{
    public abstract class Model<TConfig>
        where TConfig : Config
    {
        public TConfig Config { get; }

        public event Action OnUpdate = delegate { };
        
        protected Model(TConfig config)
        {
            Config = config;
        }

        public void CallUpdateMethod() => OnUpdate();
    }
}