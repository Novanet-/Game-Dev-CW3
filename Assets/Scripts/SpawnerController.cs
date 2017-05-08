﻿using System.Collections.Generic;
using com.kleberswf.lib.core;
using UnityEngine;

public partial class SpawnerController : Singleton<SpawnerController>
{
    #region Public Fields

    public Dictionary<string, SpawnerStruct> SpawnerDict;

    #endregion Public Fields

    #region Private Fields

    private DifficultyController _difficultyController;
    [SerializeField] private List<SpawnerStruct> _spawnerList;

    #endregion Private Fields

    #region Private Methods

    // Use this for initialization
    private void Start()
    {
        SpawnerDict = new Dictionary<string, SpawnerStruct>();
        foreach (SpawnerStruct spawner in _spawnerList)
        {
            GameObject spawnerObject = spawner._spawnerObject;
            Vector3 positionOverride = spawner._spawnerPositionOverride;

            if (!positionOverride.Equals(Vector3.zero)) spawnerObject.transform.position = positionOverride;
            SpawnerDict.Add(spawner._spawnerName, spawner);
        }

        _difficultyController = DifficultyController.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #endregion Public Structs
}