using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SG.Utils
{
    public static partial class Helper
    {
        public static class Control
        {
            public static bool IsPointerOverUIObject() 
            {
                var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
                {
                    position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
                };
                var results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
                return results.Count > 0;
            }
        }
    }
}