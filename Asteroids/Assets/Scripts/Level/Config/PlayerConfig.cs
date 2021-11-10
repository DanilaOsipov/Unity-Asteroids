using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
    public class PlayerConfig : Common.Config
    {
        [SerializeField] private float _inputSmoothTime = 0.5f;
        [SerializeField] private float _rotationSpeed = 240.0f;
        [SerializeField] private float _movementSpeed = 10.0f;
        [SerializeField] private float _bulletSpeed = 20.0f;
        [SerializeField] private float _shootDelay = 0.25f;
        
        public float InputSmoothTime => _inputSmoothTime;

        public float RotationSpeed => _rotationSpeed;

        public float MovementSpeed => _movementSpeed;

        public float BulletSpeed => _bulletSpeed;

        public float ShootDelay => _shootDelay;
    }
}