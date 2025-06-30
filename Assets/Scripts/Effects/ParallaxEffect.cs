using UnityEngine;

namespace Game
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField, Header("Speed Settings")] private Vector2 moveSpeed;
        [SerializeField] private float increaseSpeed = 0.1f;

        private Material _material;

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _material.mainTextureOffset += IncreaseSpeed();
        }

        private Vector2 IncreaseSpeed()
        {
            moveSpeed.x += increaseSpeed * Time.deltaTime;

            return moveSpeed * Time.deltaTime;
        }
    }
}