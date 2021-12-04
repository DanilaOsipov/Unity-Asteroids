using System.Collections.Generic;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
    public class PlayerConfig : Common.Config, IHealable
    {
        [SerializeField] private float _inputSmoothTime = 0.5f;
        [SerializeField] private float _rotationSpeed = 240.0f;
        [SerializeField] private float _movementSpeed = 10.0f;
        [SerializeField] private List<WeaponConfig> _weaponConfigs;
        [SerializeField] private int _health = 1;

        public float InputSmoothTime => _inputSmoothTime;

        public float RotationSpeed => _rotationSpeed;

        public float MovementSpeed => _movementSpeed;

        public List<WeaponConfig> WeaponConfigs => _weaponConfigs;

        public int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}