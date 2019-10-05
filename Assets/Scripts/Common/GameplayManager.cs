using System.Collections;
using System.Collections.Generic;

using DG.Tweening;

using Player;

using UnityEngine;


namespace Common
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }

        public Vector3 PlayerPosition => _playerCharacter.transform.position;

        private PlayerCharacter  _playerCharacter;
        private List<BasicEnemy> _enemies;

        [SerializeField] private GameObject _weaponForPlayer;

        private Coroutine _flash;

        public void RegisterEnemy(BasicEnemy enemy)
        {
            if (_enemies == null)
            {
                _enemies = new List<BasicEnemy>();
            }

            _enemies.Add(enemy);
            enemy.OnDeath += (e) => OnEnemyDown(e);
        }

        private void Awake()
        {
            Instance = this;
            _playerCharacter = FindObjectOfType<PlayerCharacter>();
            _playerCharacter.PlayerHit += OnPlayerHit;
        }

        private void OnEnemyDown(BasicEnemy enemy)
        {
            _enemies.Remove(enemy);
            Camera.main.DOShakePosition(0.2f);
            if (_enemies.Count == 1)
            {
                Instantiate(_weaponForPlayer, enemy.transform.position, Quaternion.identity);
            }
        }

        private void OnPlayerHit()
        {
            Camera.main.DOShakePosition(0.5f);
            if (_flash==null)
            {
                _flash = StartCoroutine(FlashScreen());
            }
        }

        private void OnPLayerDown()
        {
        }

        private IEnumerator FlashScreen()
        {
            var cam = Camera.main;
            var color = cam.backgroundColor;
            cam.backgroundColor = Color.white;
            cam.cullingMask = LayerMask.NameToLayer("Nothing");
            yield return new WaitForSeconds(0.05f);

            cam.cullingMask = LayerMask.NameToLayer("Everything");
            cam.backgroundColor = color;
            _flash = null;
        }
    }
}

