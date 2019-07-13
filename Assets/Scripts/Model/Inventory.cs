using Enum;
using Interface;
using Model.Weapon;
using UnityEngine;

namespace Model
{
    public class Inventory : IInit
    {
        private BaseWeapon[] _weapons = new BaseWeapon[5];
        private int _selectedWeaponIndex;
        
        public FlashlightModel FlashLight { get; private set; }
        
        public BaseWeapon[] Weapons => _weapons;
        
        public void OnStart()
        {
            // find weapons in game object hierarchy
            _weapons = Main.Instance.Player.GetComponentsInChildren<BaseWeapon>();
            // turn off all weapons
            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }
            
            FlashLight = Object.FindObjectOfType<FlashlightModel>();
            FlashLight.Switch(false);
        }
        
        public BaseWeapon SelectWeapon(int weaponNumber)
        {
            if (weaponNumber < 0 || weaponNumber >= Weapons.Length) return null;

            var tempWeapon = Weapons[weaponNumber];
            return tempWeapon;
        }
        
        public BaseWeapon SelectWeapon(MouseScrollWheel scrollWheel)
        {
            if (scrollWheel == MouseScrollWheel.Up) 
            {
                if (_selectedWeaponIndex < Weapons.Length - 1)
                {
                    _selectedWeaponIndex++;
                }
                else
                {
                    _selectedWeaponIndex = -1;
                }
                return SelectWeapon(_selectedWeaponIndex);
            }

            if (_selectedWeaponIndex <= 0)
            {
                _selectedWeaponIndex = Weapons.Length;
            }
            else
            {
                _selectedWeaponIndex--;
            }
            return SelectWeapon(_selectedWeaponIndex);
        }
    }
}