using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class ScenesLoader : MonoBehaviour
    {
        public static ScenesLoader Instance { get; private set; }

        [SerializeField] private string[] _levels;
        private int _currentIndex = -1;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadNextLevel()
        {
            if (_currentIndex >= _levels.Length - 1) return;
            _currentIndex++;
            SceneManager.LoadScene(_levels[_currentIndex]);
        }
    }
}