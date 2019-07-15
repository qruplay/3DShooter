using System;
using UnityEngine;

namespace Model.Weapon
{
    public sealed class Gun : BaseWeapon
    {
        protected override int MaxAmmunitionCount => 30;
        protected override int ClipCount => 4;
    }
}