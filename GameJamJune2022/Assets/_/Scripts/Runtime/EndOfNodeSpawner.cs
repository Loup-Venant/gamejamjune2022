using Gameplay.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Runtime
{
  public class EndOfNodeSpawner : MonoBehaviour
  {
    #region Exposed

    [Header("Spawner Properties")]
    [SerializeField, Tooltip("The global spawn speed in seconds")] private float _spawnSpeed = 1f;

    [Header("Dev DEBUG")]
    [SerializeField] private Transform[] _spawnPositions;



    #endregion

    #region Unity API

    private void Start()
    {
      Initialize();
      var script = GetComponent<MockMapGenerator>();
      script.CreateMap();
      _endNodeEntity = script.m_map;

      GetNextMapEntity();
    }

    private void Initialize()
    {
      _elapsedTime = 0f;
      _currentMapEntityIndex = 0;
    }

    private void Update()
    {
      SpawnOnTime();
    }

    #endregion


    #region Main
    private void SpawnOnTime()
    {
      _elapsedTime += Time.deltaTime;
      if (_elapsedTime >= _spawnSpeed)
      {
        _elapsedTime = 0f;
        _currentMapEntityIndex++;
        if(_currentMapEntityIndex >= _endNodeEntity)
        Spawn();
      }
    }

    private void Spawn()
    {

      var mapEntities = _endNodeEntity.GetEntitiesAtPosition(_currentMapEntityIndex);
      for (int i = 0; i < _spawnPositions.Length; i++)
      {
        if (mapEntities[i] != null)
        {
          var temp = "Prefabs/MapEntities/" + mapEntities[i].GetName();
          var mapEntity = Instantiate(Resources.Load<GameObject>(temp), _spawnPositions[i].position, Quaternion.identity);
          mapEntity.GetComponent<MapEntityBehaviour>().SetMapEntity(mapEntities[i]);
        }
      }
      GetNextMapEntity();
    }

    #endregion


    #region Hidden
    private EndNodeEntity _endNodeEntity;
    private float _elapsedTime;
    private int _currentMapEntityIndex;
    private float _nextEntitySpawnTime;

    private MapEntity[] _mapEntities = new MapEntity[Map.NumberOfLanes];

    #endregion
  }
}
