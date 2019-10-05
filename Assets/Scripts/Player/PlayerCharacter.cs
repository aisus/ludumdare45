using System;

using Common;

using Mechanics;
using Mechanics.Weapons;

using UnityEngine;


namespace Player
{
    public class PlayerCharacter : MonoBehaviour, IGameCharacter
    {
        public Action PlayerHit;
        public Action PlayerDown;
        
        private Weapon _weapon;
        
        public void RecieveDamage()
        {
            PlayerHit.Invoke();
        }
        
        public void ActivateWeapon(GameObject weaponPrefab)
        {
            var go = Instantiate(weaponPrefab, this.transform, true);
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            _weapon = go.GetComponent<Weapon>();
            _weapon.SetMaster(this);
        }

        private void Update()
        {
            if (_weapon)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _weapon.Shoot();
                }
            }

        }
    }
}
