using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Logic
{
  public class MapNode
  {
    private List<InteractableMapEntity> _mapEntities;
    private List<ICondition> _availabilityConditions;
    public EndNodeEntity m_endOfNodeEntity;
    private List<MapNode> m_NextNodes;
    public MapNode(EndNodeEntity endNode) : this(endNode, new List<InteractableMapEntity>(), new List<ICondition>())
    {

    }
    public MapNode(EndNodeEntity endNode, List<InteractableMapEntity> entities) : this(endNode, entities, new List<ICondition>())
    {

    }
    public MapNode(EndNodeEntity endNode, List<InteractableMapEntity> entities, List<ICondition> conditions)
    {
      m_NextNodes = new List<MapNode>();
      _mapEntities = entities;
      _availabilityConditions = conditions;
      m_endOfNodeEntity = endNode;
    }

    public void AddNode(MapNode newNode)
    {
      m_NextNodes.Add(newNode);
    }
    public List<MapNode> GetAvailableNodes()
    {
      return m_NextNodes.Where(n => n.IsAvailable()).ToList();
    }
    public MapNode SelectNextNode(int index)
    {
      return GetAvailableNodes()[index];
    }
    public bool IsAvailable()
    {
      if (_availabilityConditions.Count == 0)
        return true;
      return _availabilityConditions.TrueForAll(c => c.Evaluate());
    }

    internal List<InteractableMapEntity> GetEntities()
    {
      return _mapEntities;
    }
  }
}