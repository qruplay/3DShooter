using Enum;
using UnityEngine;

namespace Model.Weapon
{
    public class BaseAmmunition : BaseModel
    {
        [SerializeField] protected float lifetime = 10;
        [SerializeField] protected float baseDamage = 10;
        protected float Damage;
        protected float LossOfDamageByTime = 0.2f;

        public AmmunitionType type = AmmunitionType.Bullet;

        protected override void Awake()
        {
            base.Awake();
            Damage = baseDamage;
        }

        private void Start()
        {
            Destroy(gameObject, lifetime);
            InvokeRepeating(nameof(LoseDamage), 0, 1);
        }

        public void AddForce(Vector3 dir)
        {
            if (Rigidbody) Rigidbody.AddForce(dir);
        }

        protected void LoseDamage()
        {
            Damage -= LossOfDamageByTime;
        }
    }
}