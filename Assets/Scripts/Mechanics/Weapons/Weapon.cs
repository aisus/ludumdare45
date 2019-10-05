using UnityEngine;


namespace Mechanics.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;

        private IGameCharacter _master;
        
        public void SetMaster(IGameCharacter master)
        {
            _master = master;
        }

        public void Shoot()
        {
            var projectile = Instantiate(_projectilePrefab, this.transform.position, this.transform.rotation);
            projectile.GetComponent<Projectile>().SetMaster(_master);
        }
    }
}
