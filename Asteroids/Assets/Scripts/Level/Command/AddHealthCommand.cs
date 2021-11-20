using System.Linq;
using Common;
using Level.Other;
using UnityEngine;

namespace Level.Command
{
    public class AddHealthCommand : ICommand
    {
        private readonly IObjectPoolModel _objectPoolModel;
        private readonly string _elementId;
        private readonly int _health;

        public AddHealthCommand(IObjectPoolModel objectPoolModel, string elementId, int health)
        {
            _objectPoolModel = objectPoolModel;
            _elementId = elementId;
            _health = health;
        }

        public void Execute()
        {
            var elementModel = _objectPoolModel.Elements
                .FirstOrDefault(x => x.Id == _elementId);
            if (elementModel is not IHealable healable) return;
            healable.Health += _health;
            if (healable.Health > 0) return;
            if (elementModel.Type != EntityType.Player)
            {
                healable.Health = ((IHealable)elementModel.Config).Health;
                elementModel.IsActive = false;
                elementModel.CallUpdateMethod();
            }
            else
            {
            
            }
        }
    }
}