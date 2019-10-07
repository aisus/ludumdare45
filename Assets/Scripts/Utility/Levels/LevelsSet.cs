using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

[CreateAssetMenu]
public class LevelsSet : ScriptableObject
{
    [Serializable]
    public class Level
    {
        public string Id;
    }

    public Level[] levels;

    public string GetCurrentIndex()
    {
        var name = SceneManager.GetActiveScene().name;
        return name;
    }

    public string GetNextLevelName()
    {
        var name = SceneManager.GetActiveScene().name;

        var currentLevel = levels.First(x => x.Id == name);

        if (currentLevel != null)
        {
            var idx = Array.IndexOf(levels, currentLevel);
            if (idx < levels.Length - 1) {
                return levels[idx + 1].Id;
            }
        }
        return null;
    }
}
