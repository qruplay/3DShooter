using UnityEngine;

namespace View
{
    public class UiInterface
    {
        private FlashLightUi _flashLightUi;
        private SelectionUi _selectionUi;
        private WeaponUi _weaponUi;

        public FlashLightUi FlashLightUi
        {
            get 
            { 
                if (!_flashLightUi) _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
                return _flashLightUi;
            }
        }
        
        public SelectionUi SelectionUi
        {
            get 
            { 
                if (!_selectionUi) _selectionUi = Object.FindObjectOfType<SelectionUi>();
                return _selectionUi;
            }
        }
        
        public WeaponUi WeaponUi
        {
            get
            {
                if (!_weaponUi)
                    _weaponUi = Object.FindObjectOfType<WeaponUi>();
                return _weaponUi;
            }
        }
    }
}