using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace Game
{
    public class FootstepAudio : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private InputActionProperty moveInput;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] footstepClips;
        [SerializeField, Min(0f)] private float footstepInterval = 0.5f;

        [Header("Movement")]
        [SerializeField, Min(0f)] private float movementThreshold = 0.1f;

        private bool isMoving;
        private Coroutine footstepRoutine;

        private void Update()
        {
            Vector2 input = moveInput.action.ReadValue<Vector2>();
            bool currentlyMoving = input.magnitude > movementThreshold;

            if (currentlyMoving && !isMoving)
            {
                isMoving = true;
                footstepRoutine = StartCoroutine(PlayFootsteps());
            }
            else if (!currentlyMoving && isMoving)
            {
                isMoving = false;
                if (footstepRoutine != null) StopCoroutine(footstepRoutine);
            }
        }

        private IEnumerator PlayFootsteps()
        {
            while (isMoving)
            {
                if (footstepClips.Length > 0)
                {
                    AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
                    audioSource.PlayOneShot(clip);
                }

                yield return new WaitForSeconds(footstepInterval);
            }
        }
    }
}