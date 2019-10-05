using Player;

using UnityEngine;


namespace Common
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance
        {
            get
            {
                if (_instance)
                {
                    return _instance;
                }

                var go = new GameObject("GAMEPLAY_MANAGER");
                _instance = go.AddComponent<GameplayManager>();

                return _instance;
            }
        }

        private static GameplayManager _instance;

        public Vector3 PlayerPosition => _playerController.transform.position;

        private PlayerController _playerController;
        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }
    }
}
