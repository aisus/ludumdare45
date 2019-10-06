using Mechanics.Weapons;

using UnityEngine;


namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Range(0, 1000)]
        [SerializeField] private float _movementSpeed;

        private Rigidbody2D _rigidbody;
        private float       _lookAngle;
        private Vector2     _moveDirection;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();        
    

        private void Update()
        {
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
