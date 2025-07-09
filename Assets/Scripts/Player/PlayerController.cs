using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Management;

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
        private Vector3 _initPosition;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _initPosition = transform.position;

            ResetDevicePosition();
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

        private void ResetDevicePosition()
        {
            List<XRInputSubsystem> inputSubsystems = new List<XRInputSubsystem>();
            SubsystemManager.GetInstances(inputSubsystems);

            foreach (var subsystem in inputSubsystems)
            {
                subsystem.TryRecenter();
                Debug.Log("Recenter called on: " + subsystem.SubsystemDescriptor.id);
            }
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