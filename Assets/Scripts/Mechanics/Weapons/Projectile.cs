using System.Collections;

using UnityEngine;

using Utility;


namespace Mechanics.Weapons
{
    public class Projectile : TemporaryMonoBehaviour
    {
        [SerializeField] private float      _speed;
        [SerializeField] private GameObject _explosionPrefab;

        private IGameCharacter _someoneWhoShotThisProjectile;
        private Vector3        _direction;

        public void SetMaster(IGameCharacter master)
        {
            _someoneWhoShotThisProjectile = master;
        }

        protected override void Start()
        {
            base.Start();
            StartCoroutine(DestroyOnTimeout(5f));
            _direction = this.transform.up;
        }

        private void Update()
        {
            this.transform.position += _direction * _speed * Time.deltaTime;
            //Debug.DrawRay(this.transform.position, this.transform.up, Color.cyan, 0.5f);
        }

        private IEnumerator DestroyOnTimeout(float delay)
        {
            yield return new WaitForSeconds(delay);

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var destructable = other.gameObject.GetComponent<IGameCharacter>();
            if (destructable != null)
            {
                if (destructable != _someoneWhoShotThisProjectile)
                {
                    destructable.RecieveDamage();
                    Explode();
                }
            }
            else
            {
                var projectile = other.gameObject.GetComponent<Projectile>();
                if (projectile == null)
                {
                    Explode();
                }
            }
        }

        private void Explode()
        {
            Instantiate(_explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
