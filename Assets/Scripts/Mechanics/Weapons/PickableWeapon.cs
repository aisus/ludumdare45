using Common;
using Player;

using UnityEngine;
using Utility;


namespace Mechanics.Weapons
{
    public class PickableWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerCharacter>();
            if (player != null)
            {
                player.ActivateWeapon(_weaponPrefab);
                GameplayManager.Instance.PlaySound(GameAudioManager.SoundType.WeaponPicked);
                Destroy(this.gameObject);
            }
        }
    }
}
