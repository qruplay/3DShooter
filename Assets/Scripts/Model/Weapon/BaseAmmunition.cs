using Enum;
using UnityEngine;

namespace Model.Weapon
{
    public class BaseAmmunition : BaseModel
    {
        [SerializeField] protected float lifetime = 2;
        [SerializeField] protected float baseDamage = 10;
        protected float Damage;
        protected float DamageLossOverTime = 0.2f;

        public AmmunitionType type = AmmunitionType.Bullet;

        public void GetReadyToFire(Vector3 fireDir, Vector3 pos, Quaternion rotation)
        {
            AddForce(fireDir);
            Transform.position = pos;
            Transform.rotation = rotation;
            Damage = baseDamage;
            InvokeRepeating(nameof(LoseDamage), 0, 1);
            Invoke(nameof(ReturnToPool), lifetime);
        }

        protected void ReturnToPool()
        {
            Main.Instance.ObjectPool.AddObjectToPool("Bullet", this);
        }

        public void AddForce(Vector3 dir)
        {
            if (Rigidbody) Rigidbody.AddForce(dir);
        }

        protected void LoseDamage()
        {
            Damage -= DamageLossOverTime;
        }
    }
}