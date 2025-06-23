using DG.Tweening;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Light))]
    public class LightFlicker : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Min(0f)] private float minIntensity = 0.5f;
        [SerializeField, Min(0f)] private float flickerSpeed = 0.1f;

        private Light _flashlight;

        private void Awake()
        {
            _flashlight = GetComponent<Light>();
        }

        private void Start()
        {
            StartFlickerLoop();
        }

        private void StartFlickerLoop()
        {
            _flashlight.DOIntensity(minIntensity, flickerSpeed).SetLoops(-1, LoopType.Yoyo);
        }
    }
}