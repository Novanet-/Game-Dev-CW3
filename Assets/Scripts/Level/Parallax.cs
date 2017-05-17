using UnityEngine;

namespace Level
{
    public class Parallax : MonoBehaviour
    {
        #region Public Fields

        public Renderer[] backgrounds;
        public float step = 0.5f;
        public bool isMenu = false;

        #endregion Public Fields

        #region Private Fields

        private GameController _gameController;

        #endregion Private Fields

        #region Private Methods

        private void Start()
        {
            if (!isMenu)
                _gameController = GameObject.Find("GameController").GetComponent<Level.GameController>();
        }

        private void Update()
        {
            if (!isMenu && _gameController.IsPaused) return;

            foreach (Renderer r in backgrounds)
            {
                if (!r.isVisible && r.transform.position.y > 0)
                    r.transform.position = r.transform.position - Vector3.up * (r.bounds.size.y * 2);
                else
                    r.transform.position = r.transform.position + Vector3.up * step;
            }
        }

        #endregion Private Methods
    }
}