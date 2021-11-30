using Common;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/WeaponConfig")]
    public class WeaponConfig : Common.Config
    {
        [SerializeField] private WeaponType _type;
        [SerializeField] private int _damage;
        [SerializeField] private float _delayAfterShot = 0.25f;
        [SerializeField] private bool _isReloadable;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _shotsBeforeReload;

        public WeaponType Type => _type;
        
        public int Damage => _damage;
        
        public float DelayAfterShot => _delayAfterShot;

        public bool IsReloadable => _isReloadable;

        public float ReloadTime => _reloadTime;

        public int ShotsBeforeReload => _shotsBeforeReload;
    }
}