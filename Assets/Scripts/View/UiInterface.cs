using UnityEngine;

namespace View
{
    public class UiInterface
    {
        private FlashLightUi _flashLightUi;

        public FlashLightUi FlashLightUi
        {
            get 
            { 
                if (!_flashLightUi) _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
                return _flashLightUi;
            }
        }
    }
}