using System;
using Gameplay.Data;
using Gameplay.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
      _endOfGameTimer = 0;
      _currentMapEntityIndex = -3;
      _currentMapEntityIndexContainer.m_value = _currentMapEntityIndex;
    }
    private void ResetAfterNextNode()
    {
      _elapsedTime = 0f;
      _currentMapEntityIndex = -4;
      _currentMapEntityIndexContainer.m_value = _currentMapEntityIndex;
    }

    private void Update()
    {
      SpawnOnTime();
      GetInput();
    }

    private void GetInput()
    {
      var availableNodes = _map.GetCurrentNode().GetAvailableNodes();
      var currentEndOfNode = _map.GetCurrentNode().m_endOfNodeEntity;
      if (_currentMapEntityIndex >= currentEndOfNode.m_Position)
      {
        if (availableNodes.Count == 0)
        {
          _endOfGameTimer += Time.deltaTime;
          if (_endOfGameTimer > 15)
          {
            SceneManager.LoadScene("CreditScene");
          }
        }
        else
        {
          MapNode nextNode = null;
          if (Input.GetKeyDown(KeyCode.UpArrow) && availableNodes.Count >= 1)
          {
            nextNode = availableNodes[0];
          }
          if (Input.GetKeyDown(KeyCode.LeftArrow) && availableNodes.Count >= 2)
          {
            nextNode = availableNodes[0];
          }
          if (Input.GetKeyDown(KeyCode.RightArrow) && availableNodes.Count >= 3)
          {
            nextNode = availableNodes[0];
          }
          if (Input.GetKeyDown(KeyCode.DownArrow) && availableNodes.Count >= 4)
          {
            nextNode = availableNodes[0];
          }
          if (nextNode != null)
          {
            _map.SetNode(nextNode);
            ResetAfterNextNode();
            Debug.Log(_map.GetCurrentNode().GetChoiceText());
          }
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
        var endOfNodePosition = _map.GetCurrentNode().m_endOfNodeEntity.m_Position;
        if (_currentMapEntityIndex == endOfNodePosition)
        {
          SpawnEndNode(_map.GetCurrentNode().m_endOfNodeEntity);
        }
        if (_currentMapEntityIndex < endOfNodePosition)
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
      var temp = _map.GetCurrentNode().GetAvailableNodes();
      endOfNodeEntity.GetComponent<EndOfNode>().SetUITextChoices(temp);

      //add choice
    }

    #endregion


    #region Hidden
    private Map _map;
    private float _elapsedTime;
    private int _currentMapEntityIndex;
    private float _nextEntitySpawnTime;

    private MapEntity[] _mapEntities = new MapEntity[Map.NumberOfLanes];
    private float _endOfGameTimer;

    #endregion
  }
}
