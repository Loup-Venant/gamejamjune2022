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
      public int m_characterValue;
      public int m_enemyValue;
      public int m_itemValue;

      public InteractableMapEntity GetEntity(int position, int laneId)
      {
        switch (m_type)
        {
          case MapEntityType.Enemy:
            return new Enemy() { m_LaneId = laneId, m_Position = position, m_Value = m_enemyValue };
          case MapEntityType.Item:
            return new Item() { m_LaneId = laneId, m_Position = position, m_Value = m_itemValue };
          case MapEntityType.Character:
            return new Character() { m_LaneId = laneId, m_Position = position, m_Value = m_characterValue };
          default:
            return new Enemy() { m_LaneId = laneId, m_Position = position, m_Value = 100};
        }
      }
    }
}
