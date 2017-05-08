using UnityEngine;

namespace Sound
{
    internal class Music : MonoBehaviour
    {
        #region Public Fields

        [SerializeField] public AudioClip ExampleMusicClip;

        #endregion Public Fields

        #region Public Properties

        public static Music Instance { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        #endregion Private Methods
    }
}