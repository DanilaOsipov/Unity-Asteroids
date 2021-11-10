using Level.Config;
using Level.Model;

namespace Level.Command
{
    public class UpdateBulletPoolCommand : UpdateObjectPoolCommand<BulletPoolModel, BulletPoolConfig,
        BulletPoolElementModel, BulletPoolElementConfig>
    {
        public UpdateBulletPoolCommand(BulletPoolModel objectPoolModel) : base(objectPoolModel)
        {
        }
    }
}