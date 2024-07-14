using UnityEditor;

namespace SG.Utils.ForEditor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(LockEditTransform))]
    public class LockEditTransformEditor : Editor
    {
        private LockEditTransform _transformLocker;

        private void OnEnable()
        {
            _transformLocker = (LockEditTransform) target;
            Tools.hidden = true;
        }

        private void OnDisable()
        {
            Tools.hidden = false;
        }
    }
}