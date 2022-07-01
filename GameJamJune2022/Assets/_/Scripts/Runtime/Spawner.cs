using System;
using Gameplay.Data;
using Gameplay.Logic;
using UnityEngine;

namespace Gameplay.Runtime
{
  public class Spawner : MonoBehaviour
  {
    #region Exposed

    [Header("Spawner Properties")]
    [SerializeField, Tooltip("The global spawn speed in seconds")] private float _spawnSpeed = 1f;

    [Header("Dev DEBUG")]
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private IntValue _currentMapEntityIndexContainer;

    #endregion

    #region Unity API

    private void Start()
    {
      Initialize();
      var script = GetComponent<MockMapGenerator>();
      script.CreateMap();
      _map = script.m_map;
    }

    private void Initialize()
    {
      _elapsedTime = 0f;
      _currentMapEntityIndex = 0;
      _currentMapEntityIndexContainer.m_value = _currentMapEntityIndex;
    }

    private void Update()
    {
      SpawnOnTime();
      GetInput();
    }

    private void GetInput()
    {
      if(_currentMapEntityIndex == _map.GetCurrentNode().m_endOfNodeEntity.m_Position)
      {
          if(Input.GetButtonDown("Choice1"))
        {
          _map.GetCurrentNode().SelectNextNode(0);
          _endNodeIsSpawned = false;
        }
        if (Input.GetButtonDown("Choice2"))
        {
          _map.GetCurrentNode().SelectNextNode(1);
          _endNodeIsSpawned = false;
        }
        if (Input.GetButtonDown("Choice3"))
        {
          _map.GetCurrentNode().SelectNextNode(2);
          _endNodeIsSpawned = false;
        }
        if (Input.GetButtonDown("Choice4"))
        {
          _map.GetCurrentNode().SelectNextNode(3);
          _endNodeIsSpawned = false;
        }
      }

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
        _currentMapEntityIndexContainer.m_value = _currentMapEntityIndex;

        if(_currentMapEntityIndex >= _map.GetCurrentNode().m_endOfNodeEntity.m_Position  && !_endNodeIsSpawned)
        {
          SpawnEndNode(_map.GetCurrentNode().m_endOfNodeEntity);
        }
        SpawnInteractable();
      }
    }

    private void SpawnInteractable()
    {

      var mapEntities = _map.GetEntitiesAtPosition(_currentMapEntityIndex);
      for (int i = 0; i < _spawnPositions.Length; i++)
      {
        if (mapEntities[i] != null)
        {
          var temp = "Prefabs/MapEntities/" + mapEntities[i].GetName();
          var mapEntity = Instantiate(Resources.Load<GameObject>(temp), _spawnPositions[i].position, Quaternion.identity, transform);
          mapEntity.GetComponent<MapEntityBehaviour>().SetMapEntity(mapEntities[i]);
        }
      }
    }
    private void SpawnEndNode(EndNodeEntity endNodeEntity)
    {
      var endOfNodeEntity = Instantiate(Resources.Load<GameObject>("Prefabs/EndNodes/" + endNodeEntity.GetName()), _spawnPositions[1].position, Quaternion.identity);
      endOfNodeEntity.GetComponent<EndOfNode>().SetUITextChoices(_map.GetCurrentNode().GetAvailableNodes());

      _endNodeIsSpawned = true;
      //add choice
    }

    #endregion


    #region Hidden
    private Map _map;
    private float _elapsedTime;
    private int _currentMapEntityIndex;
    private float _nextEntitySpawnTime;

    private MapEntity[] _mapEntities = new MapEntity[Map.NumberOfLanes];
    private bool _endNodeIsSpawned;

    #endregion
  }
}
