using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;

namespace Gameplay.Data
{
    public enum MapEntityType
    {
        Enemy,
        Item,
        Character
    }
    
    [CreateAssetMenu(fileName = "New MapEntity", menuName = "Gameplay/MapEntity", order = 0)]
    public class MapEntityGenerator : ScriptableObject
    {
      public MapEntityType m_type;
      public int m_value = 4;

      public InteractableMapEntity GetEntity(int position, int laneId)
      {
        switch (m_type)
        {
          case MapEntityType.Enemy:
            return new Enemy() { m_LaneId = laneId, m_Position = position, m_Value = m_value };
          case MapEntityType.Item:
            return new Item() { m_LaneId = laneId, m_Position = position, m_Value = m_value };
          case MapEntityType.Character:
            return new Character() { m_LaneId = laneId, m_Position = position, m_Value = m_value };
          default:
            return new Enemy() { m_LaneId = laneId, m_Position = position, m_Value = 100};
        }
      }
    }
}
