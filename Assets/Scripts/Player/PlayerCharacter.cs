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

        public int Health { get; private set; }
        
        private Weapon _weapon;

        private void Awake()
        {
            Health = 2;
        }

        public void RecieveDamage()
        {
            PlayerHit.Invoke();
            Health--;
            if (Health <= 0)
            {
                PlayerDown.Invoke();
            }
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
