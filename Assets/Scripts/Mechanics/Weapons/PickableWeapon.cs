using Player;

using UnityEngine;


namespace Mechanics.Weapons
{
    public class PickableWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateWeapon(_weaponPrefab);
                Destroy(this.gameObject);
            }
        }
    }
}
