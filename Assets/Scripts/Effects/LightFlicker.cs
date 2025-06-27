using DG.Tweening;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Light))]
    public class LightFlicker : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private bool flickOnStart;
        [SerializeField, Min(0f)] private float minIntensity = 0.5f;
        [SerializeField, Min(0f)] private float flickerSpeed = 0.1f;
        [SerializeField, Min(0f)] private float flickerDuration = 1f;

        private Light _flashlight;

        private Tween _tween;

        private void Awake()
        {
            _flashlight = GetComponent<Light>();
        }

        private void Start()
        {
            if (flickOnStart)
            {
                StartFlickerLoop();
            }
        }
        
        public void StartFlickerLoop()
        {
            SetActive();
            _tween = _flashlight.DOIntensity(minIntensity, flickerSpeed).SetLoops(-1, LoopType.Yoyo);
        }

        public void FlickFewSeconds()
        {
            SetActive();
            _tween = _flashlight.DOIntensity(minIntensity, flickerDuration).OnComplete(SetInactive);
        }

        public void StopFlicker()
        {
            StopTween();
            SetInactive();
        }

        private void SetActive()
        {
            gameObject.SetActive(true);
        }

        private void SetInactive()
        {
            gameObject.SetActive(false);
        }

        private void StopTween()
        {
            if (_tween != null && _tween.IsPlaying())
            {
                _tween.Kill();
            }
        }
    }
}