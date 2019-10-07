using UnityEngine;


namespace Player
{
    public class SmoothCamera : MonoBehaviour
    {
        private                                 Transform _target;
        [Range(0, 50)] [SerializeField] private float     _smoothSpeed = 5f;
        private                                 Vector3   _offset;
        private                                 Camera    _camera;
        [SerializeField] private                float     _deadZone;

        private void Awake()
        {
            _target = FindObjectOfType<PlayerCharacter>().transform;
            _offset = Vector3.back;
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            var targToViewport = _camera.WorldToScreenPoint(_target.position);
            targToViewport = new Vector3(targToViewport.x / Screen.width, targToViewport.y / Screen.height, 1);
            var speedFactor = 1;//targToViewport.magnitude / _deadZone;
            //Debug.Log(speedFactor);
            
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, Mathf.SmoothStep(0, 1, _smoothSpeed * Time.deltaTime * speedFactor));
            
            this.transform.position = smoothedPosition;

            //transform.LookAt(_target);
        }
    }
}
