using UnityEngine;

namespace Model
{
    public abstract class BaseModel : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        public Transform Transform { get; private set; }

        private int _layer;
        private Color _color;
        private bool _isVisible;

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
            set
            {
                _layer = value;
                SetLayer(transform, value);
            }
        }

        private void SetLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;

            foreach (Transform child in obj)
            {
                SetLayer(child, layer);
            }
        }
        
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                SetColor(Transform, _color);
            }
        }
        
        private void SetColor(Transform obj, Color color)
        {
            foreach (var currentMaterial in obj.GetComponent<Renderer>().materials)
            {
                currentMaterial.color = color;
            }
            if (obj.childCount <= 0) return;
            foreach (Transform d in obj)
            {
                SetColor(d, color);
            }
        }
        
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                SetVisibility(Transform, _isVisible);
            }
        }

        private void SetVisibility(Transform obj, bool value)
        {
            var tempRenderer = obj.GetComponent<Renderer>();
            if (tempRenderer) tempRenderer.enabled = value;
            if (obj.transform.childCount <= 0) return;
            foreach (Transform d in obj.transform)
            {
                SetVisibility(d, value);
            }
        }
        
        public bool HasRigidBody() => Rigidbody;

        public void DisableRigidbody()
        {
            if (!HasRigidBody()) return;

            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
        }
        
        public void EnableRigidbody(float force)
        {
            EnableRigidbody();
            Rigidbody.AddForce(transform.forward * force);
        }

        public void EnableRigidbody()
        {
            if (!HasRigidBody()) return;

            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }
        
        public void ConstraintsRigidbody (RigidbodyConstraints rigidbodyConstraints)
        {
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.constraints = rigidbodyConstraints;
            }
        }

        public void SetActive (bool value)
        {
            IsVisible = value;

            var tempCollider = GetComponent<Collider>();
            if (tempCollider) tempCollider.enabled = value;
        }
    }
}