using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [RequireComponent(typeof(TransformAnimation))]
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
        [SerializeField] private Vector3 increaseScale;
        [SerializeField, Min(0f)] private float firstMoveDuration = 10f;
        [SerializeField, Min(0f)] private float increaseScaleDuration = 10f;
        
        private TransformAnimation transformAnimation;
        private Tween _tween;
        
        private bool _isFirstActivated = true;

        private void Awake()
        {
            transformAnimation = GetComponent<TransformAnimation>();
        }

        public void MoveToFirstPosition()
        {
            if (!_isFirstActivated) return;

            ActivateObject();
            parallaxEffect.SetMaterial(blueMaterial);
            _isFirstActivated = false;
            transformAnimation.Move(firstDestination, firstMoveDuration);
            onFirstActivated?.Invoke();
        }
        
        public void MoveToDoorPosition()
        {
            ActivateObject();
            parallaxEffect.SetMaterial(redMaterial);
            transformAnimation.Move(doorDestination, 0f);
            onDoorActivated?.Invoke();
        }
        
        public void IncreaseScale()
        {
            ActivateObject();
            transformAnimation.IncreaseScale(increaseScale, increaseScaleDuration);
        }

        private void ActivateObject()
        {
            gameObject.SetActive(true);
        }
    }
}