using com.kleberswf.lib.core;
using UnityEngine;

namespace Sound
{
    internal class Sounds : Singleton<Sounds>
    {
        #region Public Fields

        [SerializeField] public AudioClip PlayerDeath;
        [SerializeField] public AudioClip PlayerFall;
        [SerializeField] public AudioClip PickUpPowerup;

        #endregion Public Fields
    }
}