using System;
using Interface;
using UnityEngine;

namespace Model
{
    public class Aim : MonoBehaviour, IDamageable, ISelectable
    {
        public event Action OnDeath;
		
        public float hp = 100;
        private bool _isDead;
        public void SetDamage(CollisionInfo info)
        {
            if (_isDead) return;
            if (hp > 0)
            {
                hp -= info.Damage;
            }

            if (hp <= 0)
            {
                var tempRigidbody = GetComponent<Rigidbody>();
                if (!tempRigidbody)
                {
                    tempRigidbody = gameObject.AddComponent<Rigidbody>();
                }
                tempRigidbody.velocity = info.Dir;
                Destroy(gameObject, 10);

                OnDeath?.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}