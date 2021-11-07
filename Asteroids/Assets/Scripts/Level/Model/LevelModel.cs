using Level.Config;

namespace Level.Model
{
    public class LevelModel : Common.Model<LevelConfig>
    {
        public PlayerModel PlayerModel { get; }

        public LevelModel(LevelConfig config) : base(config)
        {
            PlayerModel = new PlayerModel(config.PlayerConfig);
        }
    }
}