namespace Common
{
    public abstract class Model<TConfig>
        where TConfig : Config
    {
        public TConfig Config { get; }

        protected Model(TConfig config)
        {
            Config = config;
        }
    }
}