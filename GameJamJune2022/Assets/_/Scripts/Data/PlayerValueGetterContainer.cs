using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;

namespace Gameplay.Data
{
  
  [CreateAssetMenu(menuName ="Gameplay/PlayerStatGetter")]
  public class PlayerValueGetterContainer : ScriptableObject
  {
    public PlayerContainer m_playerContainer;
    public PlayerStat m_playerStat;

    public Func<int> GetStatGetter()
    {
      switch (m_playerStat)
      {
        case PlayerStat.Money:
          return () => m_playerContainer.m_player.m_Value;
        case PlayerStat.Fame:
          return () => m_playerContainer.m_player.m_Fame;
        case PlayerStat.GodFavor:
          return () => m_playerContainer.m_player.m_Blood;
        case PlayerStat.Time:
          return () => m_playerContainer.m_player.m_Time;
        default:
          return () => m_playerContainer.m_player.m_Value;
      }
    }
    
  }
}
