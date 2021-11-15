using Common;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public abstract class ObjectPoolElementModel<TConfig> : Model<TConfig>, IObjectPoolElementModel
        where TConfig : ObjectPoolElementConfig
    {
        public string Id { get; set; }
        public EntityType Type { get; }
        public bool IsActive { get; set; }
        public Transform Transform { get; set; }
        ObjectPoolElementConfig IObjectPoolElementModel.Config => Config;
        public float Speed { get; set; }
        
        protected ObjectPoolElementModel(TConfig config) : base(config)
        {
            Type = config.Type;
        }
    }
}