namespace Model.Weapon
{
    public sealed class Pistol : BaseWeapon
    {
        protected override int MaxAmmunitionCount => 12;
        protected override int ClipCount => 6;
    }
}