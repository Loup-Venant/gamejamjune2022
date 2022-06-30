using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Logic;
using UnityEngine;
using System.Linq;

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

    }

    private void Populate(List<InteractableMapEntity> mapEntities)
    {
      for (int i = 0; i < 10; i++)
      {
        mapEntities.Add(new Item() { m_LaneId = 0, m_Position = i * 5, m_Value = 4 });
        mapEntities.Add(new Character() { m_LaneId = 1, m_Position = 1 + (i * 5), m_Value = 4 });
        mapEntities.Add(new Enemy() { m_LaneId = 2, m_Position = 2 + (i * 5), m_Value = 4 });
      }
    }

    #endregion

    #region Main

    public void CreateMap()
    {
      Map.NumberOfLanes = 3;
      var mapEntities = new List<InteractableMapEntity>();
      Populate(mapEntities);
      m_map = new Map( mapEntities.OfType<MapEntity>().ToList());
    }

    #endregion



  }
}
