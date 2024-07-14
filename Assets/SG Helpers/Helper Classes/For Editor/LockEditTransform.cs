using UnityEngine;

namespace SG.Utils.ForEditor
{
    [ExecuteInEditMode]
    public class LockEditTransform : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Awake()
        {
            ResetTransform();
        }
    
        private void OnEnable()
        {
            transform.hideFlags = HideFlags.NotEditable;
        }

        private void OnDestroy()
        {
            transform.hideFlags = HideFlags.None;
        }

        private void ResetTransform()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
#endif
    }
}