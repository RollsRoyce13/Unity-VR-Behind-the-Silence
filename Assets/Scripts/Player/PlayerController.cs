using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputActionProperty moveAction; 
        [SerializeField] private Transform cameraTransform;
        
        [Header("Settings")]
        [SerializeField, Min(0f)] private float moveSpeed = 1.5f;
        
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>();
            Vector3 direction = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * new Vector3(input.x, 0, input.y);
            Vector3 targetPosition = _rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(targetPosition);
        }
    }
}