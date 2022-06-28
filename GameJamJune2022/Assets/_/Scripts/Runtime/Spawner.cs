using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Runtime
{
    public class Spawner : MonoBehaviour
    {
        #region Exposed

        [SerializeField] private Transform[] spawnPositions;


        #endregion

        #region Unity API

        private void Update()
        {
            Spawn();
        }

        #endregion

        #region Main

        private void Spawn()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < spawnPositions.Length; i++)
                {
                    Instantiate(Resources.Load<GameObject>("Prefabs/MapEntity"), spawnPositions[i].position, Quaternion.identity);
                }
            }
        }

        #endregion

        #region Hidden

        #endregion
    }
}
