using Common;
using UnityEngine;
using Utility;

namespace Mechanics.Weapons
{
    public class TripleWeapon : Weapon
    {
        [Range(1, 10)]
        [SerializeField] private int _bulletsPerShot;
        [Range(10, 120)]
        [SerializeField] private float _spreadAngle;

        public override void Shoot()
        {
            var angleStep = _spreadAngle / _bulletsPerShot;
            var initialAngle = -_spreadAngle / 2;

            for (int i = 0; i < _bulletsPerShot; i++)
            {
                ShotOneShot(initialAngle + angleStep * i);
            }
            GameplayManager.Instance.PlaySound(GameAudioManager.SoundType.EnemyShot);
        }

        private void ShotOneShot(float angle)
        {
            var projectile = Instantiate(_projectilePrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0 , angle));
            projectile.GetComponent<Projectile>().SetMaster(_master);
        }
    }
}
