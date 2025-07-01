using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ParallaxEffect : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector2 moveSpeed;
        [SerializeField] private float increaseSpeed = 0.1f;

        private MeshRenderer _meshRenderer;
        private Material _material;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            UpdateMaterial();
        }

        private void Update()
        {
            Move();
        }

        public void SetMaterial(Material material)
        {
            _meshRenderer.material = material;
            UpdateMaterial();
        }

        private void Move()
        {
            if (_material == null) return;
            
            _material.mainTextureOffset += IncreaseSpeed();
        }
        
        private void UpdateMaterial()
        {
            _material = _meshRenderer.material;
        }

        private Vector2 IncreaseSpeed()
        {
            moveSpeed.x += increaseSpeed * Time.deltaTime;

            return moveSpeed * Time.deltaTime;
        }
    }
}