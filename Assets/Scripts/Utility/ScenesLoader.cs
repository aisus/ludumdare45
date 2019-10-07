using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class ScenesLoader : MonoBehaviour
    {
        public static ScenesLoader Instance { get; private set; }

        [SerializeField]
        private LevelsSet levelsSet;

        private void Awake()
        {
            Instance = this;
        }

        public void LoadNextLevel()
        {
            var name = levelsSet.GetNextLevelName();
            if (name != null) {
                SceneManager.LoadScene(name);
            }
        }
    }
}