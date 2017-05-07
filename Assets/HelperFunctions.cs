using JetBrains.Annotations;
using UnityEngine;

namespace Assets
{
    public class HelperFunctions
    {
        public static void ClampTransformToCameraView([NotNull] Transform transform)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}