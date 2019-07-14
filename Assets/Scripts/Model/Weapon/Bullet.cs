using Interface;
using UnityEngine;

namespace Model.Weapon
{
    public class Bullet : BaseAmmunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            var hitObject = collision.gameObject.GetComponent<IDamageable>();
            if (hitObject != null)
                hitObject.SetDamage(new CollisionInfo(Damage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));

            Main.Instance.ObjectPool.AddObjectToPool("Bullets", this);
        }
    }
}