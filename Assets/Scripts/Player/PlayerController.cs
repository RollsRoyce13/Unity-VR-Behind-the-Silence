using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    [RequireComponent(typeof(XROrigin))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private InputActionProperty moveAction; 
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform spawnPoint;
        
        [Header("Settings")]
        [SerializeField, Min(0f)] private float moveSpeed = 1.5f;

        private XROrigin _xrOrigin;
        private Rigidbody _rigidbody;
        private Vector3 _initPosition;
        
        private void Awake()
        {
            _xrOrigin = GetComponent<XROrigin>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            StartCoroutine(PositionPlayerAtSpawn());
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void MoveToInitPosition()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            transform.position = _initPosition;
        }

        private void Move()
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>();
            Vector3 direction = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * new Vector3(input.x, 0, input.y);
            Vector3 targetPosition = _rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(targetPosition);
        }
        
        private IEnumerator PositionPlayerAtSpawn()
        {
            yield return null; // Wait for XR to initialize

            Vector3 headOffset = GetHeadOffsetXZ();
            SetOriginPosition(headOffset);
            AlignOriginRotation();
            
            _initPosition = transform.position;
        }
        
        private Vector3 GetHeadOffsetXZ()
        {
            Vector3 offset = _xrOrigin.Camera.transform.position - _xrOrigin.transform.position;
            offset.y = 0f;
            return offset;
        }

        private void SetOriginPosition(Vector3 headOffset)
        {
            _xrOrigin.transform.position = spawnPoint.position - headOffset;
        }

        private void AlignOriginRotation()
        {
            Vector3 headForward = _xrOrigin.Camera.transform.forward;
            headForward.y = 0f;
            headForward.Normalize();

            Vector3 targetForward = spawnPoint.forward;
            targetForward.y = 0f;
            targetForward.Normalize();

            Quaternion rotationDelta = Quaternion.FromToRotation(headForward, targetForward);
            _xrOrigin.transform.rotation = rotationDelta * _xrOrigin.transform.rotation;
        }
    }
}