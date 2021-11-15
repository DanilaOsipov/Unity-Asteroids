using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.View
{
    public class SpawnerView : View<SpawnerModel>
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EntityType _entityType;
        private float _spawnDelay;

        public EntityType Type => _entityType;

        public List<Transform> SpawnPoints => _spawnPoints;

        public event Action<EntityType> OnReadyToSpawn = delegate(EntityType type) { };
        
        public override void UpdateView(SpawnerModel data)
        {
            _spawnDelay = data.Config.SpawnDelay;
        }

        public void StartSpawnCoroutine()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                OnReadyToSpawn(_entityType);
            }
        }
    }
}