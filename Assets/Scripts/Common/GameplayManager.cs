using System.Collections.Generic;

using DG.Tweening;

using Player;

using UnityEngine;


namespace Common
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }

        public Vector3 PlayerPosition => _playerController.transform.position;

        private PlayerController _playerController;
        private List<BasicEnemy> _enemies;

        [SerializeField] private GameObject _weaponForPlayer;

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
            _playerController = FindObjectOfType<PlayerController>();
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
        }

        private void OnPLayerDown()
        {
        }
    }
}
