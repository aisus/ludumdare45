using UnityEngine;


namespace Utility
{
    public class TemporaryObjectsManager : MonoBehaviour
    {
        public static TemporaryObjectsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("TEMPORARY_OBJECTS").AddComponent<TemporaryObjectsManager>();
                }

                return _instance;
            }
        }

        private static TemporaryObjectsManager _instance;

        public void Register(GameObject go) => go.transform.SetParent(this.transform);
    }
}
