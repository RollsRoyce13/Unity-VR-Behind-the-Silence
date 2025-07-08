using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class TransformAnimation : MonoBehaviour
    {
        private Tween _tween;

        private void OnDisable()
        {
            StopTween();
        }
        
        public void Move(Vector3 destination, float duration)
        {
            _tween = transform.DOMove(destination, duration);
        }

        public void IncreaseScale(Vector3 newScale, float duration)
        {
            _tween = transform.DOScale(newScale, duration);
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