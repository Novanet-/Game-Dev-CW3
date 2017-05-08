using com.kleberswf.lib.core;
using UnityEngine;

namespace Sound
{
    internal class Music : Singleton<Music>
    {
        #region Public Fields

        [SerializeField] public AudioClip ExampleMusicClip;

        #endregion Public Fields
    }
}