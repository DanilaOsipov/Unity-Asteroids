using System.Linq;
using Common;
using Level.Config;
using Level.Model;
using Level.View;
using UnityEngine;

namespace Level.Command
{
    public abstract class UpdateObjectPoolCommand<TModel, TConfig, TElementModel, TElementConfig> : ICommand
        where TModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
        where TElementModel : ObjectPoolElementModel<TElementConfig>
        where TElementConfig : ObjectPoolElementConfig
        where TConfig : ObjectPoolConfig<TElementConfig>
    {
        private readonly TModel _objectPoolModel;

        protected UpdateObjectPoolCommand(TModel objectPoolModel)
        {
            _objectPoolModel = objectPoolModel;
        }
        
        public void Execute()
        {
            foreach (var elementModel in _objectPoolModel.Elements.Where(elementModel => elementModel.IsActive))
            {
                elementModel.Transform.position += elementModel.Transform
                    .up * (elementModel.Speed * Time.deltaTime);
            }
        }
    }
}