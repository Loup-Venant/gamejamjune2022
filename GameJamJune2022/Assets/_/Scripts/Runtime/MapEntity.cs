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
      
      private void SetMapEntity(InteractableMapEntity mapEntity)
      {
        m_mapEntity = mapEntity;
      }

      public void HitByPlayer(Player m_player)
      {
        m_mapEntity.Choose(m_player, m_player.m_IsPassive);

        
        Destroy(gameObject, .5f);
        
      }

      #endregion
      
    }
}
