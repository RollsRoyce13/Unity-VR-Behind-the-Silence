using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class RandomAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        
        private AudioSource _audioSource;
        private Coroutine _audioCoroutine;
        
        private bool _isPlaying;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();;
        }

        private void Start()
        {
            Initialization();
        }

        public void StopPlaying()
        {
            _isPlaying = false;
            
            if (_audioCoroutine != null)
            {
                StopCoroutine(_audioCoroutine);
            }
        }

        private void Initialization()
        {
            if (audioClips.Length > 0 && _audioSource != null)
            {
                _isPlaying = true;
                _audioCoroutine = StartCoroutine(PlayRandomAudio());
            }
            else
            {
                Debug.LogWarning("No AudioClips assigned or AudioSource missing in RandomAudioPlayer script.");
            }
        }

        private IEnumerator PlayRandomAudio()
        {
            while (_isPlaying)
            {
                AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
                
                _audioSource.clip = randomClip;
                _audioSource.Play();
                
                yield return new WaitForSeconds(randomClip.length);
            }
        }

    }
}