using UnityEngine;

namespace Sound
{
    public class SoundController : MonoBehaviour
    {
        #region Private Fields

        [SerializeField] private float _highPitchRange = 1.05f;
        [SerializeField] private float _lowPitchRange = .95f;
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _soundSource;

        #endregion Private Fields

        #region Public Properties

        public static SoundController Instance { get; set; }

        #endregion Public Properties

        #region Public Methods

        //Used to play single sound clips.
        public void PlayMusic(AudioClip clip)
        {
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip, float volumeScale)
        {
            _soundSource.PlayOneShot(clip, volumeScale);
        }

        //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
        public void RandomizeSfx(params AudioClip[] clips)
        {
            int randomIndex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(_lowPitchRange, _highPitchRange);

            _soundSource.pitch = randomPitch;
            _soundSource.clip = clips[randomIndex];

            _soundSource.Play();
        }

        #endregion Public Methods

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