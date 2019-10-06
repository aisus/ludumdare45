using UnityEngine;
using UnityEngine.UI;

public class UiConrtoller : MonoBehaviour
{
    [SerializeField] private Image[] _healthIndicators;

    private int _currentIndex = 0;

    public void DispayHealthLost()
    {
        if (_currentIndex < _healthIndicators.Length - 1)
        {
            _healthIndicators[_currentIndex].color = Color.black;
            _currentIndex++;
        }
    }
}
