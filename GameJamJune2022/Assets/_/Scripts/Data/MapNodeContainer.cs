using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;
using System.Linq;

namespace Gameplay.Data
{
  [CreateAssetMenu(menuName ="Gameplay/MapNodeContainer")]
  public class MapNodeContainer : ScriptableObject
  {
    private MapNode m_Node;

    public string m_ChoiceName;
    public List<MapNodeContainer> m_nextNodes = new List<MapNodeContainer>();
    public List<ConditionContainer> m_conditions = new List<ConditionContainer>();
    public EndNodeContainer m_endNode;
    public TrackContainer m_interactables;
    public int m_WastedTime;


    public MapNode GetNode()
    {
      if (m_Node == null)
      {
        m_nextNodes = m_nextNodes.Where(n => n != null).ToList();
        m_Node = new MapNode(m_endNode.GetEntity(), m_interactables.GetEntities(), m_conditions.Select(c => c.GetCondition()).ToList())
        {m_ChoiceName = m_ChoiceName, m_WastedTime = m_WastedTime};
        foreach(var n in m_nextNodes)
        {
          AddNode(n);
        }
      }
      return m_Node;
    }
    private void AddNode(MapNodeContainer node)
    {
      GetNode().AddNode(node.GetNode());
    }
  }
}
