using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Other;
using Level.View;
using UnityEngine;

namespace Level.Command
{
    public class HandleLevelTriggerExitCommand : ICommand
    {
        private readonly Collider2D _collider;
        private readonly List<IObjectPoolModel> _objectPoolModels;

        public HandleLevelTriggerExitCommand(Collider2D collider, List<IObjectPoolModel> objectPoolModels)
        {
            _collider = collider;
            _objectPoolModels = objectPoolModels;
        }
        
        public void Execute()
        {
            var playerView = _collider.GetComponent<PlayerView>();
            if (playerView != null)
            {
                
                return;
            }
            var objectPoolElement = _collider.GetComponent<IObjectPoolElement>();
            if (objectPoolElement != null)
            {
                var objectPoolModel = _objectPoolModels
                    .FirstOrDefault(x => x.ElementType == objectPoolElement.Type);
                objectPoolModel?.SetElementActive(objectPoolElement.Id, false);
            }
        }
    }
}