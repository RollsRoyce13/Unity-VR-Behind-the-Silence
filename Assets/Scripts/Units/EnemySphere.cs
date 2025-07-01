using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [RequireComponent(typeof(MoveToPosition))]
    public class EnemySphere : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private UnityEvent onFirstActivated;
        [SerializeField] private UnityEvent onDoorActivated;

        [Header("References")] 
        [SerializeField] private ParallaxEffect parallaxEffect;
        
        [Header("Materials")]
        [SerializeField] private Material blueMaterial;
        [SerializeField] private Material redMaterial;
        
        [Header("Settings")] 
        [SerializeField] private Vector3 firstDestination;
        [SerializeField] private Vector3 doorDestination;
        [SerializeField, Min(0f)] private float firstMoveDuration = 10f;
        
        private MoveToPosition _moveToPosition;
        private Tween _tween;
        
        private bool _isFirstActivated = true;

        private void Awake()
        {
            _moveToPosition = GetComponent<MoveToPosition>();
        }

        public void MoveToFirstPosition()
        {
            if (!_isFirstActivated) return;

            ActivateObject();
            parallaxEffect.SetMaterial(blueMaterial);
            _isFirstActivated = false;
            _moveToPosition.Move(firstDestination, firstMoveDuration);
            onFirstActivated?.Invoke();
        }
        
        public void MoveToDoorPosition()
        {
            ActivateObject();
            parallaxEffect.SetMaterial(redMaterial);
            _moveToPosition.Move(doorDestination, 0f);
            onDoorActivated?.Invoke();
        }

        private void ActivateObject()
        {
            gameObject.SetActive(true);
        }
    }
}