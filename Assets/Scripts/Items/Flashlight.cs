using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class Flashlight : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private UnityEvent<bool> onStateChanged;
        
        [Header("Input")]
        [SerializeField] private InputActionProperty triggerInput;

        [Header("Flashlight")]
        [SerializeField] private LightFlicker lightFlicker;

        private bool _isOn = true;

        private void OnEnable()
        {
            triggerInput.action.started += OnTriggerPressed;
            triggerInput.action.Enable();
        }

        private void OnDisable()
        {
            triggerInput.action.started -= OnTriggerPressed;
            triggerInput.action.Disable();
        }

        private void OnTriggerPressed(InputAction.CallbackContext context)
        {
            _isOn = !_isOn;
            lightFlicker.gameObject.SetActive(_isOn);
            onStateChanged?.Invoke(_isOn);
        }
    }
}