using System;
using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class EnemySphere : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector3 firstDestination;
        [SerializeField, Min(0f)] private float firstMoveDuration = 10f;
        
        private Tween _tween;
        
        private bool _isFirstActivated = true;
        
        private void OnEnable()
        {
            MoveToFirstPosition();
        }

        private void MoveToFirstPosition()
        {
            if (!_isFirstActivated) return;
            
            _isFirstActivated = false;
            _tween = transform.DOMove(firstDestination, firstMoveDuration);
        }
    }
}