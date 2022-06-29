using System;
using System.Collections.Generic;

namespace Gameplay.Logic
{
  public class Map
  {
    public static int NumberOfLanes;

    public Dictionary<int, MapEntity>[] m_Lanes;
    public Dictionary<int, Decision> m_History;
    private MapNode _firstNode;
    public Map(MapNode firstNode) : base()
    {
      _firstNode = firstNode;
    }
    public Map(List<MapEntity> allEntities) : base()
    {
      AddEntities(allEntities);
    }
    public Map()
    {
      m_Lanes = new Dictionary<int, MapEntity>[NumberOfLanes];
      m_History = new Dictionary<int, Decision>();
    }
    public void AddEntities(List<MapEntity> entities)
    {
      foreach (var entity in entities)
      {
        if (entity.m_LaneId >= 0 && entity.m_LaneId <= m_Lanes.Length && !m_Lanes[entity.m_LaneId].ContainsKey(entity.m_Position))
          m_Lanes[entity.m_LaneId].Add(entity.m_Position, entity);
      }
    }
    public void AddEntity(MapEntity entity, int lane, int position)
    {
      m_Lanes[lane].Add(position, entity);
    }
    public void AddPlayerPositionToHistory(int pos, int lane)
    {
      AddPlayerPositionToHistory(pos, new Decision(lane));
    }
    public void AddPlayerPositionToHistory(int pos, int lane, MapEntity entity, bool choice)
    {
      AddPlayerPositionToHistory(pos, new Decision(lane, entity, choice));
    }
    private void AddPlayerPositionToHistory(int pos, Decision decision)
    {
      m_History.Add(pos, decision);
    }
  }
  public class MapNode
  {
    private List<MapEntity> _mapEntities;
    private List<ICondition> _availabilityConditions;
    public MapNode(List<MapEntity> entities)
    {
      _mapEntities = entities;
    }
  }
  public interface ICondition
  {
    public Type ValueType { get; }
    public bool Evaluate(object value);
  }
  public struct MapNodeCondition<T> :ICondition where T : IComparable, IEquatable<T>
  {
    private bool isLower;
    private bool isEqual;
    private T valueReference;
    public Type ValueType { get; private set; }
    public MapNodeCondition(T valueRef, bool equal, bool lower)
    {
      valueReference = valueRef;
      isEqual = equal;
      isLower = lower;
      ValueType = typeof(T);
    }


    public bool Evaluate(T value)
    {
      var retval = false;
      if (isEqual)
        retval = value.Equals(valueReference);
      if (isLower)
        retval |= value.CompareTo(valueReference) == -1;
      return retval;
    }

    public bool Evaluate(object value)
    {
      var cast = (T)value;
      if(cast != null)
        return Evaluate(cast);
      throw new ArgumentException("The type of the value does not match the type of the condition");
    }
  }
}