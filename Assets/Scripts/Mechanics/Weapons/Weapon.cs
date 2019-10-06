using UnityEngine;


namespace Mechanics.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected GameObject _projectilePrefab;

        protected IGameCharacter _master;
        
        public void SetMaster(IGameCharacter master)
        {
            _master = master;
        }

        public virtual void Shoot()
        {
            var projectile = Instantiate(_projectilePrefab, this.transform.position, this.transform.rotation);
            projectile.GetComponent<Projectile>().SetMaster(_master);
        }
    }
}
