using UnityEngine;

namespace Model
{
    public abstract class BaseModel : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        public Transform Transform { get; private set; }

        private int _layer;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
        }

        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }
        
        public int Layer
        {
            get => _layer;
            set => SetLayer(transform, value);
        }

        private void SetLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;

            foreach (Transform child in obj)
            {
                SetLayer(child, layer);
            }
        }
    }
}