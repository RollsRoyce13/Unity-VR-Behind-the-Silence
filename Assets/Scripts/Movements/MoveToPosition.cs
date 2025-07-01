using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class MoveToPosition : MonoBehaviour
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

        private void StopTween()
        {
            if (_tween != null && _tween.IsPlaying())
            {
                _tween.Kill();
            }
        }
    }
}