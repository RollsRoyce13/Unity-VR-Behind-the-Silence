using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class TriggerZone : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private UnityEvent onTriggerEnter;
        [SerializeField] private UnityEvent onTriggerExit;

        [Header("Settings")]
        [SerializeField] private bool isEnterTriggeredOnce;
        [SerializeField] private bool isExitTriggeredOnce;

        private bool _isEnterTriggered;
        private bool _isExitTriggered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            
            if (isEnterTriggeredOnce && _isEnterTriggered) return;
            
            _isEnterTriggered = true;
            Debug.Log($"Trigger enter on object: {name}");
            onTriggerEnter?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            
            if (isExitTriggeredOnce && _isExitTriggered) return;

            _isExitTriggered = true;
            Debug.Log($"Trigger exit on object: {name}");
            onTriggerExit?.Invoke();
        }
    }
}