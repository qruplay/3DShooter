using UnityEngine;

namespace Helper
{
    public struct CollisionInfo
    {
        private readonly Vector3 _dir;
        private readonly float _damage;
        private readonly ContactPoint _contact;
        private readonly Transform _objCollision;
        private readonly string _message;
        
        public CollisionInfo(float damage, ContactPoint contact, 
            Transform objCollision, Vector3 dir = default(Vector3)) : this()
        {
            _damage = damage;
            _dir = dir;
            _contact = contact;
            _objCollision = objCollision;
        }

        public CollisionInfo(string message) : this()
        { 
            _message = message;
        }

        public Vector3 Dir => _dir;

        public float Damage => _damage;

        public ContactPoint Contact => _contact;

        public Transform ObjCollision => _objCollision;

        public string Message => _message;
    }
}