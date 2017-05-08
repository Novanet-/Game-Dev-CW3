using UnityEngine;

namespace Level
{
    public class Parallax : MonoBehaviour
    {
        #region Public Fields

        public Renderer[] Backgrounds;
        public float Step = 0.5f;

        #endregion Public Fields

        #region Private Methods

        private void Update()
        {
            foreach (Renderer r in Backgrounds)
            {
                if (!r.isVisible && r.transform.position.y > 0)
                    r.transform.position = r.transform.position - Vector3.up * (r.bounds.size.y * 2);
                else
                    r.transform.position = r.transform.position + Vector3.up * Step;
            }
        }

        #endregion Private Methods
    }
}