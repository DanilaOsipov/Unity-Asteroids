using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Command;
using Level.Config;
using Level.Model;
using Level.Other;
using UI;
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
        [SerializeField] private SmallAsteroidPoolView _smallAsteroidPoolView;
        [SerializeField] private EnemyPoolView _enemyPoolView;
        [SerializeField] private LaserProjectilePoolView _laserProjectilePoolView;
        [SerializeField] private List<SpawnerView> _spawnerViews;
        private List<IObjectPoolView> _objectPoolViews;
        private LevelModel _levelModel;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            _controls.Main.BulletShoot.performed += OnPlayerShootBulletHandler;
            _controls.Main.LaserShoot.performed += OnPlayerShootLaserHandler;
            _levelModel = new LevelModel(_levelConfig) {BoxCollider2D = GetComponent<BoxCollider2D>()};
            InitializePlayer();
            InitializeObjectPools();
            InitializeSpawners();
            UIPanelsContainerView.Instance.ShowPanel(UIPanelType.PlayerInfoPanel);
        }

        private void OnDestroy()
        {
            _controls.Main.BulletShoot.performed -= OnPlayerShootBulletHandler;
            _controls.Main.LaserShoot.performed -= OnPlayerShootLaserHandler;
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

        private void InitializePlayer()
        {
            _levelModel.PlayerModel.Transform = _playerView.transform;
            foreach (var weaponModel in _levelModel.PlayerModel.WeaponModels)
            {
                weaponModel.Transform = _playerView.WeaponViews
                    .FirstOrDefault(x => x.Type == weaponModel.Config.Type)
                    ?.transform;
            }
            _playerView.Initialize(_levelModel.PlayerModel);
            _playerView.OnCollisionEnter += delegate(EntityType type, string id,
                Collision2D collision)
            {
                var checkEntityCollisionCommand
                    = new CheckEntityCollisionCommand(_levelModel, type, id, collision);
                checkEntityCollisionCommand.Execute(); 
            };
        }

        private void InitializeSpawners()
        {
            foreach (var spawnerModel in _levelModel.SpawnerModels)
            {
                var spawnerView = _spawnerViews
                    .FirstOrDefault(x => x.Type == spawnerModel.Config.Type);
                if (spawnerView == null) continue;
                spawnerModel.SpawnPoints = spawnerView.SpawnPoints;
                spawnerView.OnReadyToSpawn += delegate(EntityType type)
                {
                    var spawnEntityCommand = new SpawnEntityCommand(type, _levelModel);
                    spawnEntityCommand.Execute();
                };
                spawnerView.UpdateView(spawnerModel);
                spawnerView.StartSpawnCoroutine();
            }
        }

        private void InitializeObjectPools()
        {
            _objectPoolViews = new List<IObjectPoolView>
            {
                _bulletPoolView, _bigAsteroidPoolView, _smallAsteroidPoolView,
                _enemyPoolView, _laserProjectilePoolView
            };
            foreach (var poolView in _objectPoolViews)
            {
                var objectPoolModel = _levelModel.ObjectPoolModels
                    .FirstOrDefault(x => x.ElementType == poolView.ElementType);
                poolView.Initialize(objectPoolModel);
                foreach (var elementModel in objectPoolModel.Elements)
                {
                    elementModel.Transform = poolView.Elements
                        .FirstOrDefault(x => x.Id == elementModel.Id)?.Transform;
                }
                objectPoolModel.OnUpdate += delegate { poolView.UpdateView(objectPoolModel); };
                poolView.OnCollisionEnter += (type, id, collision) =>
                {
                    var checkEntityCollisionCommand
                        = new CheckEntityCollisionCommand(_levelModel, type, id, collision);
                    checkEntityCollisionCommand.Execute();
                };
            }
        }

        private void Update()
        {
            if (!_levelModel.IsUpdating) return;
            HandleInput();
            UpdateObjectPools();
            UpdatePlayerInfo();
        }

        private void UpdatePlayerInfo()
        {
            var updatePlayerInfoPanelCommand
                = new UpdatePlayerInfoPanelCommand(_levelModel.PlayerModel);
            updatePlayerInfoPanelCommand.Execute();
        }

        private void UpdateObjectPools()
        {
            foreach (var updateBulletPoolCommand in _levelModel.ObjectPoolModels
                .Select(objectPoolModel => new UpdateObjectPoolCommand(_levelModel,
                    objectPoolModel.ElementType)))
            {
                updateBulletPoolCommand.Execute();
            }
        }
        
        private void HandleInput()
        {
            var playerModel = _levelModel.PlayerModel;
            var moveVector = _controls.Main.Move.ReadValue<Vector2>();
            var movePlayerCommand = new MovePlayerCommand(playerModel, moveVector);
            movePlayerCommand.Execute();
        }

        private void OnPlayerShootBulletHandler(InputAction.CallbackContext context)
        {
            var shootCommand = new ShootCommand(WeaponType.BulletGun, _levelModel);
            shootCommand.Execute();
        }

        private void OnPlayerShootLaserHandler(InputAction.CallbackContext context)
        {
            var shootCommand = new ShootCommand(WeaponType.LaserGun, _levelModel);
            shootCommand.Execute();
        }

        public override void UpdateView(LevelModel data)
        {
        }

        public override void Initialize(LevelModel data)
        {
        }
    }
}