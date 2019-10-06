using UnityEngine;


namespace Player
{
    public class SmoothCamera : MonoBehaviour
    {
        private Transform _target;
        [Range(0, 50)]
        [SerializeField] private float   _smoothSpeed = 5f;
        private                  Vector3 _offset;

        private void Awake()
        {
            _target = FindObjectOfType<PlayerCharacter>().transform;
            _offset = Vector3.back;
        }

        private void Update()
        {
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, Mathf.SmoothStep(0, 1, _smoothSpeed * Time.deltaTime));
            this.transform.position = smoothedPosition;

            //transform.LookAt(_target);
        }
    }
}
