using Helper;
using Interface;
using UnityEngine;

namespace Model.Weapon
{
    public class Bullet : BaseAmmunition
    {
        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log(Rigidbody.isKinematic);
            var hitObject = collision.gameObject.GetComponent<IDamageable>();
            // ReSharper disable once UseNullPropagation
            if (hitObject != null)
            {
                hitObject.SetDamage(new CollisionInfo(Damage, collision.transform, Rigidbody.velocity));
            }
            
            Main.Instance.ObjectPool.AddObjectToPool("Bullets", this);
        }
    }
}