using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

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

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static void Fork<T>(
            this IEnumerable<T> source,
            Func<T, bool> pred,
            out IEnumerable<T> matches,
            out IEnumerable<T> nonMatches)
        {
            var groupedByMatching = source.ToLookup(pred);
            matches = groupedByMatching[true];
            nonMatches = groupedByMatching[false];
        }

        public static Vector3 RandomPointInBox(Vector3 center, Vector3 size)
        {

            return center + new Vector3(
                       (Random.value - 0.5f) * size.x,
                       (Random.value - 0.5f) * size.y,
                       (Random.value - 0.5f) * size.z
                   );
        }

        #endregion Public Methods
    }
}