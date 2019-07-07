using UnityEngine;

namespace Model
{
    public class FlashlightModel : BaseModel
    {
        private Light _light;
        private Transform _pointToFollow;
        private Vector3 _flashlightPosOffset;
        public float BatteryCharge { get; private set; }
        [SerializeField] private float followSpeed = 10;
        [SerializeField] private float maxBatteryCharge;
        
        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            if (Camera.main != null) _pointToFollow = Camera.main.transform;
            _flashlightPosOffset = Transform.position - _pointToFollow.position;
            BatteryCharge = maxBatteryCharge;
        }
        
        public void Switch(bool value)
        {
            _light.enabled = value;
            if (!value) return;
            Transform.position = _pointToFollow.position + _flashlightPosOffset;
            Transform.rotation = _pointToFollow.rotation;
        }
        
        public void Rotate()
        {
            if (!_light) return;
            Transform.position = _pointToFollow.position + _flashlightPosOffset;
            Transform.rotation = Quaternion.Lerp(Transform.rotation,
                _pointToFollow.rotation, followSpeed * Time.deltaTime);
        }
        
        public bool LoseBatteryCharge()
        {
            if (BatteryCharge <= 0) return false;
            BatteryCharge -= Time.deltaTime;
            return true;
        }

        public bool RestoreBatteryCharge()
        {
            if (BatteryCharge >= maxBatteryCharge) return false;
            BatteryCharge += Time.deltaTime;
            return true;
        }

        public float GetBatteryChargeInPercent()
        {
            return BatteryCharge / maxBatteryCharge;
        }
    }
}