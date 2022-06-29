using System.Collections.Generic;

namespace Gameplay.Logic
{
  public class MapNode
  {
    private List<MapEntity> _mapEntities;
    private List<ICondition> _availabilityConditions;
    public MapNode() : this(new List<MapEntity>(), new List<ICondition>())
    {

    }
    public MapNode(List<MapEntity> entities) : this(entities, new List<ICondition>())
    {

    }
    public MapNode(List<MapEntity> entities, List<ICondition> conditions)
    {
      _mapEntities = entities;
      _availabilityConditions = conditions;
    }

    public bool IsAvailable()
    {
      if (_availabilityConditions.Count == 0)
        return true;
      return _availabilityConditions.TrueForAll(c => c.Evaluate());
    }
  }

}