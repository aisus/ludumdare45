using Player;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            FindObjectOfType<PlayerCharacter>().ActivateWeapon(_weaponPrefab);
            _startButton.onClick.AddListener(ScenesLoader.Instance.LoadNextLevel);
        }
    }
}
