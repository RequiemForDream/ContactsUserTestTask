using UnityEngine;

namespace UI
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private bool _isActiveByAwake;

        public virtual void Awake()
        {
            gameObject.SetActive(_isActiveByAwake);
        }
    }
}
