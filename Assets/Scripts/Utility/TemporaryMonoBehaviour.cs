using UnityEngine;


namespace Utility
{
    public class TemporaryMonoBehaviour : MonoBehaviour
    {
        protected virtual void Start() => TemporaryObjectsManager.Instance.Register(this.gameObject);
    }
}
