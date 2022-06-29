using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Logic;
using UnityEngine;


namespace Gameplay.Runtime
{
    public class MockMapGenerator : MonoBehaviour
    {
        #region Exposed

        public Map m_map;

        #endregion

        #region Unity API

        private void Start()
        {
          Map.NumberOfLanes = 3;
          List<MapEntity> mapEntities = new List<MapEntity>();
          Populate(mapEntities);
          m_map = new Map(mapEntities);
        }

        private void Populate(List<MapEntity> mapEntities)
        {
          for (int i = 0; i < 10; i++)
          {
            mapEntities.Add(new Item(){m_LaneId = 0, m_Position = i * 5, m_Value = 4});
            mapEntities.Add(new Character(){m_LaneId = 1, m_Position = 2 + (i * 5), m_Value = 4});
            mapEntities.Add(new Ennemy(){m_LaneId = 3, m_Position = 3 + (i * 5), m_Value = 4});
          }
        }

        #endregion



    }
}
