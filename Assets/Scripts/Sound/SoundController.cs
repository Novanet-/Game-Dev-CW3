using com.kleberswf.lib.core;
using Entity;
using UnityEngine;

namespace Sound
{
    public class SoundController : Singleton<SoundController>
    {
        #region Private Fields

        [SerializeField] private float _highPitchRange = 1.05f;
        [SerializeField] private float _lowPitchRange = .95f;
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _soundSource;

        #endregion Private Fields

        #region Public Methods

        //Used to play single sound clips.
        public void PlayMusic(AudioClip clip)
        {
            if (_musicSource != null)
            {
                _musicSource.clip = clip;
                _musicSource.loop = true;
                _musicSource.Play();
            }
        }

        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip, float volumeScale)
        {
            if (_soundSource != null) _soundSource.PlayOneShot(clip, volumeScale / 10f);
        }

        //PlayRandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
        public void PlayRandomizeSfx(float volume, params AudioClip[] clips)
        {
            int randomIndex = Random.Range(0, clips.Length);
            _soundSource.pitch = Random.Range(_lowPitchRange, _highPitchRange);
            _soundSource.clip = clips[randomIndex];
            _soundSource.volume = volume/10;

            _soundSource.Play();
        }

        #endregion Public Methods

        public void PlayFireSound(EnemyFireController enemyFireController)
        {
            if (_soundSource != null) _soundSource.pitch = Random.Range(_lowPitchRange, _highPitchRange);
            PlaySingle(enemyFireController.FireSound, 0.5f);
//            PlayRandomizeSfx(0.05f, enemyFireController.FireSound);
        }

        public void PlayFireSound(EnemyFireController enemyFireController, float volumeOverride)
        {
            if (_soundSource != null) _soundSource.pitch = Random.Range(_lowPitchRange, _highPitchRange);
            PlaySingle(enemyFireController.FireSound, volumeOverride);
//            PlayRandomizeSfx(volumeOverride, enemyFireController.FireSound);
        }

        public void PlayUIHoverSound()
        {
            PlaySingle(Sounds.Instance.UIHover, 0.8f);
        }
    }
}