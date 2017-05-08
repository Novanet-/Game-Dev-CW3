using com.kleberswf.lib.core;
using UnityEngine;

namespace Sound
{
    internal class Sounds : Singleton<Sounds>
    {
        #region Public Fields

        [SerializeField] public AudioClip ExampleSoundClip;
        [SerializeField] public AudioClip FollowingDrumHitClip;
        [SerializeField] public AudioClip GoatSwitchSwooshClip;

        #endregion Public Fields
    }
}