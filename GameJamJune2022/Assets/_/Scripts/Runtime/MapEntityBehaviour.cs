using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;

namespace Gameplay.Runtime
{
    public class MapEntityBehaviour : MonoBehaviour
    {
      #region Exposed
      
      [Header ("Dev DEBUG")]
      public InteractableMapEntity m_mapEntity;

      #endregion

      #region Main
      
      public void SetMapEntity(InteractableMapEntity mapEntity)
      {
        m_mapEntity = mapEntity;
      }

      public void HitByPlayer(Player m_player)
      {
        m_mapEntity.Choose(m_player, m_player.m_IsPassive);

        
        Destroy(gameObject, .1f);
        
      }

      #endregion
      
    }
}
