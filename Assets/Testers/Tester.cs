using SG.Utils;
using UnityEngine;

namespace SG.Tests
{
    public class Tester : MonoBehaviour
    {
        [ContextMenu("Test")]
        public void Test()
        {
            var formatter = new BigNumberSplitFormatter(",");
            Debug.Log(formatter.Get(100306576700m));
        }
    }
}