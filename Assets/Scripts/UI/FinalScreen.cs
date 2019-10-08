using Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Button _startButton;

    private void Start()
    {
        //FindObjectOfType<PlayerCharacter>().ActivateWeapon(_weaponPrefab);
        _startButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}
