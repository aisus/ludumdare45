using System.Collections;

using UnityEngine;

using Utility;


namespace Mechanics.Weapons
{
    public class Projectile : TemporaryMonoBehaviour
    {
        [SerializeField] private float _speed;

        private IGameCharacter _someoneWhoShotThisProjectile;

        public void SetMaster(IGameCharacter master)
        {
            _someoneWhoShotThisProjectile = master;
        }

        protected override void Start()
        {
            base.Start();
            StartCoroutine(DestroyOnTimeout(5f));
        }

        private void Update()
        {
            this.transform.position += this.transform.up * _speed * Time.deltaTime;
            Debug.DrawRay(this.transform.position, this.transform.up, Color.cyan, 0.5f);
        }
    
        private IEnumerator DestroyOnTimeout(float delay)
        {
            yield return new WaitForSeconds(delay);

            Destroy(this.gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var destructable = other.gameObject.GetComponent<IGameCharacter>(); 
            if (destructable != null && destructable != _someoneWhoShotThisProjectile)
            {
                destructable.DoDamage();
                Destroy(this.gameObject);
            }
        }
    }
}
