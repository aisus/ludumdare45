using UnityEngine;
using UnityEngine.SceneManagement;


namespace Utility
{
    public class PauseAndResetManager : MonoBehaviour
    {
        private                  bool       _isPaused;
        [SerializeField] private GameObject _PauseUi;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPause();
            }
        
            if (Input.GetKeyDown(KeyCode.F5))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private void SetPause()
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
            _PauseUi.SetActive(_isPaused);
        }
    }
}
