using JetBrains.Annotations;
using UnityEngine;

namespace Misc
{
    internal static class HelperFunctions
    {
        #region Public Methods

        public static void ClampTransformToCameraView([NotNull] Transform transform)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        #endregion Public Methods
    }
}