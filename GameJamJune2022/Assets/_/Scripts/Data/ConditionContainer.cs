using Gameplay.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Data
{
  [CreateAssetMenu(menuName ="Gameplay/NodeConditionContainer")]
  public class ConditionContainer : ScriptableObject
  {
    private ICondition _condition;
    public PlayerValueGetterContainer m_playerValue; // enum in m_playerValue.m_playerStat
    public bool m_isEqual, m_isLower;
    public int m_value;


    public ICondition GetCondition()
    {
      if( _condition == null )
        _condition = new MapNodeCondition<int>(m_value,m_isEqual,m_isLower,m_playerValue.GetStatGetter());
      return _condition;
    }
  }
}
