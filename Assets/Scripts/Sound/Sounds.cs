using UnityEngine;

namespace Sound
{
    internal class Sounds : MonoBehaviour
    {
        #region Public Fields

        [SerializeField] public AudioClip ExampleSoundClip;
        [SerializeField] public AudioClip FollowingDrumHitClip;
        [SerializeField] public AudioClip GoatSwitchSwooshClip;

        #endregion Public Fields

        #region Public Properties

        public static Sounds Instance { get; set; }

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