using System.Collections.Generic;
using UnityEngine;

namespace Model.Weapon
{
    public abstract class BaseWeapon : BaseModel
    {
        protected int MaxAmmunitionCount = 30;
        protected int ClipCount = 5;
        
        public BaseAmmunition Ammunition { get; protected set; }
        public Clip clip;

        [SerializeField] protected Transform firePosition;
        [SerializeField] protected float fireForce;
        [SerializeField] protected float rechargeTime;
        
        private Queue<Clip> _clips = new Queue<Clip>();

        protected bool CanFire = true;

        protected virtual void Start()
        {
            InitClips();
        }
        
        public abstract void Fire();

        protected void SetFireAvailable()
        {
            CanFire = true;
        }

        protected void InitClips()
        {
            for (var i = 0; i <= ClipCount; i++)
            {
                AddClip(new Clip { AmmunitionCount = MaxAmmunitionCount });
            }
            
            ReloadClip();
        }

        protected void AddClip(Clip clipToAdd)
        {
            _clips.Enqueue(clipToAdd);
        }

        public void ReloadClip()
        {
            if (ClipLeftCount <= 0) return;
            clip = _clips.Dequeue();
        }

        public int ClipLeftCount => _clips.Count;
    }
}