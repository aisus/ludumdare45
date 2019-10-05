using System.Collections;

using UnityEngine;

using Utility;


namespace Mechanics.Enemies
{
    public class DeathEffect : TemporaryMonoBehaviour
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(DestroyOnTimeout(5f));
            var ps = GetComponent<ParticleSystem>();
            ps.Play();
        }
    
        private IEnumerator DestroyOnTimeout(float delay)
        {
            yield return new WaitForSeconds(delay);

            Destroy(this.gameObject);
        }
    }
}
