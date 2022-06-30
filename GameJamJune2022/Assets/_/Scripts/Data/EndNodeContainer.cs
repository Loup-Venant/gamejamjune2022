using Gameplay.Logic;
using UnityEngine;

namespace Gameplay.Data
{
  [CreateAssetMenu(menuName ="Gameplay/EndNodeContainer")]
  public class EndNodeContainer : ScriptableObject
  {
    private EndNodeEntity _endNodeEntity;
    public string m_name;
    public int m_position;

    public EndNodeEntity GetEntity()
    {
      if (_endNodeEntity == null)
        _endNodeEntity = new EndNodeEntity(m_name, m_position);
      return _endNodeEntity;
    }
  }
}
