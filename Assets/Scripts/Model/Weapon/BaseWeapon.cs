using System.Collections.Generic;
using UnityEngine;

namespace Model.Weapon
{
    public abstract class BaseWeapon : BaseModel
    {
        protected abstract int MaxAmmunitionCount { get; }
        protected abstract int ClipCount { get; }

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

        public virtual void Fire()
        {
            if (!CanFire) return;
            if (clip.AmmunitionCount <= 0) return;
            var tempAmmunition = (Bullet)Main.Instance.ObjectPool.GetObjectFromPool("Bullet");
            tempAmmunition.GetReadyToFire(firePosition.forward * fireForce, firePosition.position, firePosition.rotation);
            clip.AmmunitionCount--;
            CanFire = false;
            Invoke(nameof(SetFireAvailable), rechargeTime);
        }

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