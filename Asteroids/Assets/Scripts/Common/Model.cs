namespace Common
{
    public abstract class Model<TConfig>
        where TConfig : Config
    {
        private TConfig Config { get; }

        protected Model(TConfig config)
        {
            Config = config;
        }
    }
}