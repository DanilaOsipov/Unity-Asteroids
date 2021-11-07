using System;
using Common;
using Level.Command;
using Level.Config;
using Level.Model;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

namespace Level.View
{
    public class LevelView : View<LevelModel>
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private PlayerView _playerView;
        private LevelModel _levelModel;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls(); 
            _levelModel = new LevelModel(_levelConfig);
            _levelModel.PlayerModel.SetTransform(_playerView.transform);
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            var playerModel = _levelModel.PlayerModel;
            var moveVector = _controls.Main.Move.ReadValue<Vector2>();
            var movePlayerCommand = new MovePlayerCommand(playerModel, moveVector);
            movePlayerCommand.Execute();
        }

        public override void UpdateView(LevelModel data)
        {
        }
    }
}