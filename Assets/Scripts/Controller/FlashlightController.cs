using Interface;
using Model;

namespace Controller
{
    public class FlashlightController : BaseController, IUpdate
    {
        private FlashlightModel _flashLight;

        public void OnUpdate()
        {
            if (!IsActive && _flashLight != null)
            {
                if (_flashLight.RestoreBatteryCharge()) UpdateFlashLightUi();
                return;
            }
            if (_flashLight == null) return;

            _flashLight.Rotate();

            if (_flashLight.LoseBatteryCharge())
            {
                UpdateFlashLightUi();
            }
            else
            {
                Off();
            }
        }

        public override void On()
        {
            if (IsActive) return;
            base.On();
            _flashLight = Main.Instance.inventory.FlashLight;
            _flashLight.Switch(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLight = Main.Instance.inventory.FlashLight;
            _flashLight.Switch(false);
        }

        private void UpdateFlashLightUi()
        {
            _flashLight = Main.Instance.inventory.FlashLight;
            var chargeAmount = _flashLight.GetBatteryChargeInPercent();

            UiInterface.FlashLightUi.Energy = chargeAmount;
        }
    }
}