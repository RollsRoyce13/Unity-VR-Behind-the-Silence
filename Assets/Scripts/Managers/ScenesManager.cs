using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class ScenesManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Min(0f)] private float sceneLoadDelay = 1f;

        private Coroutine _delayedLoadSceneCoroutine;

        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning("No more scenes to load");
                return;
            }
            
            SceneManager.LoadScene(nextSceneIndex);
        }

        public void LoadNextSceneWithDelay()
        {
            if (IsStartedDelayedCoroutine()) return;
            
            _delayedLoadSceneCoroutine = StartCoroutine(DelayedLoadNextScene());
        }

        public void LoadScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
        
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        private bool IsStartedDelayedCoroutine()
        {
            return _delayedLoadSceneCoroutine != null;
        }
        
        private IEnumerator DelayedLoadNextScene()
        {
            yield return new WaitForSeconds(sceneLoadDelay);
            
            LoadNextScene();
            _delayedLoadSceneCoroutine = null;
        }
    }
}