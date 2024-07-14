using UnityEngine;

namespace SG.Utils
{
    public class StaticWorldRotation : MonoBehaviour
    {
        [SerializeField] private Vector3 _eulerRotation;

        private Quaternion _quaternionRotation;

        private void Awake()
        {
            _quaternionRotation = Quaternion.Euler(_eulerRotation);
        }

        private void Update()
        {
            transform.rotation = _quaternionRotation;
        }
    }
}
