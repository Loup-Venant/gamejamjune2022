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

    public string m_haiku;
    public List<MapNodeContainer> m_nextNodes = new List<MapNodeContainer>();
    public List<ConditionContainer> m_conditions = new List<ConditionContainer>();
    public EndNodeContainer m_endNode;
    public List<InteractableMapEntity> m_interactables = new List<InteractableMapEntity>();


    public MapNode GetNode()
    {
      if (m_Node == null)
      {
        m_Node = new MapNode(m_endNode.GetEntity(), m_interactables, m_conditions.Select(c => c.GetCondition()).ToList());
        foreach(var n in m_nextNodes)
        {
          AddNode(n);
        }
      }
      return m_Node;
    }
    private void AddNode(MapNodeContainer node)
    {
      node.m_Node.AddNode(node.GetNode());
    }
  }
}
