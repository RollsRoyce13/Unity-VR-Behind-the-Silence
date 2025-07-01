using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class PlaySound : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip)
        {
            if (clip == null) return;
            
            _audioSource.PlayOneShot(clip);
        }
        
        public void PlayDefaultClip()
        {
            if (_audioSource.clip == null) return;
            
            _audioSource.Play();
        }
    }
}