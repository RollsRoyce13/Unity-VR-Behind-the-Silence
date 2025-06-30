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
    }
}