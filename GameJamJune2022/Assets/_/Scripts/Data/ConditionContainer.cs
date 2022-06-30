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
    public PlayerValueGetterContainer m_playerValue;
    public bool m_isEqual, m_isLower;
    public int m_value;


    public ICondition GetCondition()
    {
      if( _condition == null )
        _condition = new MapNodeCondition<int>();
      return _condition;
    }
  }
}
