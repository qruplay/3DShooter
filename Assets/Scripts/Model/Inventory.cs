using Interface;
using UnityEngine;

namespace Model
{
    public class Inventory : IInit
    {
        public FlashlightModel FlashLight { get; private set; }
        
        public void OnStart()
        {
            FlashLight = Object.FindObjectOfType<FlashlightModel>();
            FlashLight.Switch(false);
        }
    }
}