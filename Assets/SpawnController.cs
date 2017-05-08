using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    #region Public Fields

    public Dictionary<string, SpawnerStruct> SpawnerDict;

    #endregion Public Fields

    #region Private Fields

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
            Vector3 positionOverride = spawner._spawnerPosition;

            if (!positionOverride.Equals(Vector3.zero)) spawnerObject.transform.position = positionOverride;
            SpawnerDict.Add(spawner._spawnerName, spawner);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #endregion Private Methods

    #region Public Structs

    [Serializable]
    public struct SpawnerStruct
    {
        #region Private Fields

        [SerializeField] public string _spawnerName;
        [SerializeField] public Vector3 _spawnerPosition;
        [SerializeField] public GameObject _spawnerObject;

        #endregion Private Fields
    }

    #endregion Public Structs
}