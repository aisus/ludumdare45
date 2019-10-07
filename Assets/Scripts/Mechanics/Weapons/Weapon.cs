using Common;
using UnityEngine;
using UnityEngine.UI;
using Utility;


namespace Mechanics.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected GameObject _projectilePrefab;
        [SerializeField] private Image _image;

        protected IGameCharacter _master;
        
        public void SetMaster(IGameCharacter master)
        {
            _master = master;
        }

        public virtual void Shoot()
        {
            var projectile = Instantiate(_projectilePrefab, this.transform.position, this.transform.rotation);
            projectile.GetComponent<Projectile>().SetMaster(_master);
            GameplayManager.Instance.PlaySound(GameAudioManager.SoundType.EnemyShot);
        }

        public void SetFillSprite(float value)
        {
            if (_image)
            {
                _image.fillAmount = value;
            }
        }

        private void Awake()
        {
            SetFillSprite(1);
        }
    }
}
