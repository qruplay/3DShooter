using Enum;
using Interface;
using Model;
using Model.Weapon;
using UnityEngine;

namespace Controller
{
    public class WeaponController : BaseController, IUpdate
    {
        private BaseWeapon _weapon;
        private int _mouseButton = (int)MouseButton.LeftButton;

        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetMouseButton(_mouseButton))
            {
                _weapon.Fire();
                UiInterface.WeaponUi.ShowData(_weapon.clip.AmmunitionCount, _weapon.ClipLeftCount);
            }
        }

        public override void On(BaseModel weapon)
        {
            if (IsActive) return;
            base.On(weapon);
            _weapon = weapon as BaseWeapon;
            if (_weapon == null) return;
            _weapon.IsVisible = true;
            UiInterface.WeaponUi.SetActive(true);
            UiInterface.WeaponUi.ShowData(_weapon.clip.AmmunitionCount, _weapon.ClipLeftCount);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            UiInterface.WeaponUi.SetActive(false);
        }

        public void ReloadClip()
        {
            if (_weapon == null) return;
            _weapon.ReloadClip();
            UiInterface.WeaponUi.ShowData(_weapon.clip.AmmunitionCount, _weapon.ClipLeftCount);
        }
    }
}