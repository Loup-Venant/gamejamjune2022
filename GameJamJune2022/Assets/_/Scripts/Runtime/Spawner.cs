using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;

namespace Gameplay.Runtime
{
    public class Spawner : MonoBehaviour
    {
        #region Exposed

        [Header ("Spawner Properties")]
        [SerializeField, Tooltip("The global spawn speed in seconds")] private float _spawnSpeed = 1f;

        [Header ("Dev DEBUG")]
        [SerializeField] private Transform[] _spawnPositions;



        #endregion

        #region Unity API

        private void Start()
        {
            Initialize();

            _map = GetComponent<MockMapGenerator>().m_map;

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
                Spawn();
            }
        }

        private void GetNextMapEntity()
        {
            // _mapEntities = _map.GetEntitiesAtPosition(_currentMapEntityIndex);
        }

        private void Spawn()
        {
            
            MapEntity[] _mapEntities = _map.GetEntitiesAtPosition(_currentMapEntityIndex);
            for(int i = 0; i < _spawnPositions.Length; i++)
            {
                if(_mapEntities[i] != null)
                {
                    var mapEntity = Instantiate(Resources.Load<GameObject>("Prefabs/MapEntity/" + _mapEntities[i].GetType().ToString()), _spawnPositions[i].position, Quaternion.identity);
                }
            }
            GetNextMapEntity();
        }

        #endregion


        #region Hidden
        private Map _map;
        private float _elapsedTime;
        private int _currentMapEntityIndex;
        private float _nextEntitySpawnTime;

        private MapEntity[] _mapEntities = new MapEntity[Map.NumberOfLanes];

        #endregion
    }
}
