using System.Linq;
using Common;
using Level.Other;
using Level.View;
using UnityEngine;

namespace Level.Command
{
    public class UpdateObjectPoolCommand : ICommand
    {
        private readonly IObjectPoolModel _objectPoolModel;

        public UpdateObjectPoolCommand(IObjectPoolModel objectPoolModel)
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