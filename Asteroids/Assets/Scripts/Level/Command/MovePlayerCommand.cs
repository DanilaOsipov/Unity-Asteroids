using Common;
using Level.Model;
using UnityEngine;

namespace Level.Command
{
    public class MovePlayerCommand : ICommand
    {
        private readonly Vector2 _moveVector;
        private readonly PlayerModel _playerModel;

        public MovePlayerCommand(PlayerModel playerModel, Vector2 moveVector)
        {
            _playerModel = playerModel;
            _moveVector = moveVector;
        }
        
        public void Execute()
        {
            var rotation = _moveVector.x;
            Debug.Log("rotation " + rotation);
            var movement = _moveVector.y;
            Debug.Log("movement " + movement);
            // _playerModel.Transform
        }
    }
}