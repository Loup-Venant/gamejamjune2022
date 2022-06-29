using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _spawnSpeed)
            {
                _elapsedTime = 0f;
                Spawn();
            }
        }

        #endregion

        #region Main

        private void Spawn()
        {
            
            for(int i = 0; i < _spawnPositions.Length; i++)
            {
                var mapEntity = Instantiate(Resources.Load<GameObject>("Prefabs/MapEntity"), _spawnPositions[i].position, Quaternion.identity);
            }
        }

        #endregion

        #region Hidden
        private float _elapsedTime;

        #endregion
    }
}
