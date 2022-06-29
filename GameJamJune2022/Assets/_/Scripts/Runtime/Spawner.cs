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
            _elapsedTime = 0f;
            GetNextMapEntity();
            Spawn();
        }

        private void Update()
        {
            
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _nextEntitySpawnTime * _spawnSpeed)
            {
                _elapsedTime = 0f;
                Spawn();
            }
        }

        private void GetNextMapEntity()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Main

        private void Spawn()
        {
            
            for(int i = 0; i < _spawnPositions.Length; i++)
            {
                if(_mapEntities[i] != null)
                {
                    var mapEntity = Instantiate(Resources.Load<GameObject>("Prefabs/MapEntity/" + _mapEntities[i].ToString()), _spawnPositions[i].position, Quaternion.identity);
                }
            }
            GetNextMapEntity();
        }

        #endregion


        #region Hidden
        private float _elapsedTime;
        private float _nextEntitySpawnTime;

        private MapEntity[] _mapEntities = new MapEntity[Map.NumberOfLanes];

        #endregion
    }
}
