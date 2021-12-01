using Common;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerInfoPanelView : UIPanelView<PlayerInfoPanelData>
    {
        [SerializeField] private TMP_Text _playerPosition;
        [SerializeField] private TMP_Text _playerRotation;
        [SerializeField] private TMP_Text _playerVelocity;
        [SerializeField] private TMP_Text _laserShots;
        [SerializeField] private TMP_Text _laserReloadTime;
        
        public override UIPanelType Type => UIPanelType.PlayerInfoPanel;
        
        public override void Initialize(UIPanelData data)
        {
        }
        
        protected override void UpdateView(PlayerInfoPanelData data)
        {
            _playerPosition.text = "Position: " + data.PlayerPosition;
            _playerRotation.text = "Rotation: " + data.PlayerRotation;
            _playerVelocity.text = "Velocity: " + data.PlayerVelocity;
            _laserShots.text = "Laser shots: " + data.CurrentLaserShots / data.LaserShotsBeforeReload;
            _laserReloadTime.text = "Laser reload time: " + data.LaserReloadTime;
        }
    }

    public class PlayerInfoPanelData : UIPanelData
    {
        public Vector2 PlayerPosition { get; }
        public Quaternion PlayerRotation { get; }
        public Vector2 PlayerVelocity { get; }
        public int CurrentLaserShots { get; }
        public int LaserShotsBeforeReload { get; }
        public float LaserReloadTime { get; }

        public PlayerInfoPanelData(Vector2 playerPosition, Quaternion playerRotation,
            Vector2 playerVelocity, int currentLaserShots, int laserShotsBeforeReload,
            float laserReloadTime)
        {
            PlayerPosition = playerPosition;
            PlayerRotation = playerRotation;
            PlayerVelocity = playerVelocity;
            CurrentLaserShots = currentLaserShots;
            LaserShotsBeforeReload = laserShotsBeforeReload;
            LaserReloadTime = laserReloadTime;
        }
    }
}