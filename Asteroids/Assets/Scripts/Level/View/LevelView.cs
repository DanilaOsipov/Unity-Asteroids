using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Command;
using Level.Config;
using Level.Model;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Level.View
{
    public class LevelView : View<LevelModel>
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private BulletPoolView _bulletPoolView;
        private LevelModel _levelModel;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            _controls.Main.Shoot.performed += OnPlayerShootHandler;
            _levelModel = new LevelModel(_levelConfig);
            _levelModel.PlayerModel.Transform = _playerView.transform;
            InitializeBulletPool();
        }

        private void OnDestroy()
        {
            _controls.Main.Shoot.performed -= OnPlayerShootHandler;
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var handleLevelTriggerExitCommand 
                = new HandleLevelTriggerExitCommand(other, _levelModel.ObjectPoolModels);
            handleLevelTriggerExitCommand.Execute();
        }

        private void InitializeBulletPool()
        {
            _bulletPoolView.UpdateView(_levelModel.BulletPoolModel);
            foreach (var elementModel in _levelModel.BulletPoolModel.Elements)
            {
                elementModel.Transform = _bulletPoolView.Elements
                    .FirstOrDefault(x => x.Id == elementModel.Id)?.transform;
            }
            _levelModel.BulletPoolModel
                .OnUpdate += delegate { _bulletPoolView.UpdateView(_levelModel.BulletPoolModel); };
        }

        private void Update()
        {
            HandleInput();
            UpdateObjectPools();
        }

        private void UpdateObjectPools()
        {
            var updateBulletPoolCommand = new UpdateBulletPoolCommand(_levelModel.BulletPoolModel);
            updateBulletPoolCommand.Execute();
        }
        
        private void HandleInput()
        {
            var playerModel = _levelModel.PlayerModel;
            var moveVector = _controls.Main.Move.ReadValue<Vector2>();
            var movePlayerCommand = new MovePlayerCommand(playerModel, moveVector);
            movePlayerCommand.Execute();
        }

        private void OnPlayerShootHandler(InputAction.CallbackContext context)
        {
            var playerModel = _levelModel.PlayerModel;
            var bulletPoolModel = _levelModel.BulletPoolModel;
            var shootCommand = new ShootCommand(playerModel, bulletPoolModel);
            shootCommand.Execute();
        }

        public override void UpdateView(LevelModel data)
        {
        }
    }
}