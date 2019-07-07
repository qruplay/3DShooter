using Interface;
using UnityEngine;

namespace Controller
{
    public class InputController : BaseController, IInit, IUpdate
    {
        private KeyCode _switchFlashLight = KeyCode.F;
        
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
        }
    }
}