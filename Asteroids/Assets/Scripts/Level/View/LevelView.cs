using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Command;
using Level.Config;
using Level.Model;
using Level.Other;
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
        [SerializeField] private BigAsteroidPoolView _bigAsteroidPoolView;
        private List<IObjectPoolView> _objectPoolViews;
        private LevelModel _levelModel;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            _controls.Main.Shoot.performed += OnPlayerShootHandler;
            _levelModel = new LevelModel(_levelConfig) {BoxCollider2D = GetComponent<BoxCollider2D>()};
            _levelModel.PlayerModel.Transform = _playerView.transform;
            InitializeObjectPools();
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
                = new HandleLevelTriggerExitCommand(other, _levelModel);
            handleLevelTriggerExitCommand.Execute();
        }

        private void InitializeObjectPools()
        {
            _objectPoolViews = new List<IObjectPoolView> {_bulletPoolView
                // , _bigAsteroidPoolView
                
            };
            foreach (var poolView in _objectPoolViews)
            {
                var objectPoolModel = _levelModel.ObjectPoolModels
                    .FirstOrDefault(x => x.ElementType == poolView.ElementType);
                poolView.UpdateView(objectPoolModel);
                foreach (var elementModel in objectPoolModel.Elements)
                {
                    elementModel.Transform = poolView.Elements
                        .FirstOrDefault(x => x.Id == elementModel.Id)?.Transform;
                }
                objectPoolModel.OnUpdate 
                    += delegate { poolView.UpdateView(objectPoolModel); };
            }
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