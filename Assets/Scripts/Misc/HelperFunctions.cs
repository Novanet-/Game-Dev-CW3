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

        #endregion Public Methods
    }
}