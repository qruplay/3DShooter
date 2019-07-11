using System;
using UnityEngine;

namespace Model.Weapon
{
    public sealed class Gun : BaseWeapon
    {
        protected override void Start()
        {
            base.Start();
            
            Ammunition = Resources.Load<Bullet>("Bullet");
        }
        
        public override void Fire()
        {
            if (!CanFire) return;
            if (clip.AmmunitionCount <= 0) return;
            if (!Ammunition) return;
            // TODO: replace Instantiate with objects pool
            var tempAmmunition = Instantiate(Ammunition, firePosition.position, firePosition.rotation);
            tempAmmunition.AddForce(firePosition.forward * fireForce);
            clip.AmmunitionCount--;
            CanFire = false;
            Invoke(SetFireAvailable, rechargeTime);
        }


        private void Invoke(Action action, float time)
        {
            Invoke(action.Method.Name, time);
        }
    }
}