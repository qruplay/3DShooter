using Enum;
using Interface;
using Model.Weapon;
using UnityEngine;

namespace Controller
{
    public class InputController : BaseController, IInit, IUpdate
    {
        private KeyCode _switchFlashLight = KeyCode.F;
        private KeyCode _reloadClip = KeyCode.R;
        
        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        
        public void OnStart()
        {
            On();
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_switchFlashLight))
            {
                Main.Instance.flashlightController.Switch();
            }
            
            if (Input.GetKeyDown(_reloadClip))
            {
                Main.Instance.weaponController.ReloadClip();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0);
            }
            
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                MouseScroll(MouseScrollWheel.Up);
            }
			
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                MouseScroll(MouseScrollWheel.Down);
            }
        }
        
        private void MouseScroll(MouseScrollWheel value)
        {
            var tempWeapon = Main.Instance.inventory.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }
        
        private void SelectWeapon(int value)
        {
            var tempWeapon = Main.Instance.inventory.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }
        
        private void SelectWeapon(BaseWeapon weapon)
        {
            Main.Instance.weaponController.Off();
            if (weapon != null)
            {
                Main.Instance.weaponController.On(weapon);
            }
        }
    }
}