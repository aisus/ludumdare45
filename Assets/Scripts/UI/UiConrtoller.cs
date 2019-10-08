using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common;
using Utility;

public class UiConrtoller : MonoBehaviour
{
    [SerializeField] private Image[] _healthIndicators;
    [SerializeField] private GameObject _deathUi;
    [SerializeField] private GameObject _PauseUi;
    [SerializeField] private GameObject _winUi;

    private bool _isPaused;

    private int _currentIndex = 0;

    public void DispayHealthLost()
    {
        if (_currentIndex < _healthIndicators.Length - 1)
        {
            _healthIndicators[_currentIndex].color = Color.black;
            _currentIndex++;
        }
        else
        {
            _healthIndicators[_currentIndex].color = Color.black;
            _deathUi.SetActive(true);
        }
    }

    public void ActivateWinUi()
    {
        _winUi.SetActive(true);
    }

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
        GameplayManager.Instance.PlaySound(GameAudioManager.SoundType.PausePress);
    }
}
