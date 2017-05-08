using System;
using com.kleberswf.lib.core;
using UnityEngine;

public partial class SpawnerController : Singleton<SpawnerController>
{
    #region Public Structs

    [Serializable]
    public struct SpawnerStruct
    {
        #region Public Fields

        [SerializeField] public string SpawnerName;
        [SerializeField] public GameObject SpawnerObject;
        [SerializeField] public Vector3 SpawnerPositionOverride;

        #endregion Public Fields
    }

    #endregion Public Structs
}