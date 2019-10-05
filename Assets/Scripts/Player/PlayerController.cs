using Mechanics.Weapons;

using UnityEngine;


namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private Rigidbody2D _rigidbody;
        private float       _lookAngle;
        private Vector2     _moveDirection;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

        private Weapon _weapon;
        
        public void ActivateWeapon(GameObject weaponPrefab)
        {
            var go = Instantiate(weaponPrefab, this.transform, true);
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            _weapon = go.GetComponent<Weapon>();
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

            var xRaw = Input.GetAxisRaw("Horizontal");
            var yRaw = Input.GetAxisRaw("Vertical");

            _moveDirection = new Vector2(xRaw, yRaw).normalized * _movementSpeed;

            var lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var lookDir = lookPos - this.transform.position;

            _lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _moveDirection * Time.fixedDeltaTime;
            _rigidbody.MoveRotation(Quaternion.Euler(0, 0, _lookAngle));
        }
    }
}
