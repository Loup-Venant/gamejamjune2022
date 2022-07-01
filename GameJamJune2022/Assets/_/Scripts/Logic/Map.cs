using System;
using System.Collections.Generic;

namespace Gameplay.Logic
{
  public class Map
  {
    public static int NumberOfLanes;

    public Dictionary<int, InteractableMapEntity>[] m_Lanes;
    public Dictionary<int, Decision> m_History;
    private MapNode _firstNode;
    private MapNode _currentNode;

    #region Constructors

    public Map(MapNode firstNode) : this()
    {
      _firstNode = firstNode;
      StartGame();
    }

    public Map(List<InteractableMapEntity> allEntities) : this()
    {
      _firstNode = new MapNode(new EndNodeEntity("temple", 50), allEntities);
      StartGame();
    }
    public Map()
    {
      m_Lanes = new Dictionary<int, InteractableMapEntity>[NumberOfLanes];
      for (int i = 0; i < NumberOfLanes; i++)
      {
        m_Lanes[i] = new Dictionary<int, InteractableMapEntity>();
      }
      m_History = new Dictionary<int, Decision>();
      _firstNode = new MapNode(new EndNodeEntity("temple", 50));
    }


    #endregion
    private void StartGame()
    {
      SetNode(_firstNode);
    }

    #region Getters

    public MapNode GetFirstNode()
    { return _firstNode; }
    public MapNode GetCurrentNode()
    { return _currentNode; }
    public void SetNode(MapNode node)
    {
      _currentNode = node;
      PopulateMap();
    }
    public InteractableMapEntity[] GetEntitiesAtPosition(int position)
    {
      var retVal = new InteractableMapEntity[NumberOfLanes];

      for (int i = 0; i < NumberOfLanes; i++)
      {
        if (m_Lanes[i].ContainsKey(position))
          retVal[i] = m_Lanes[i][position];
      }
      return retVal;
    }

    #endregion

    #region Add content

    public void PopulateMap()
    {
      foreach (var d in m_Lanes)
      {
        d.Clear();
      }
      var temp = _currentNode.GetEntities();
      AddEntities(_currentNode.GetEntities());
    }
    public void AddEntities(List<InteractableMapEntity> entities)
    {
      foreach (var entity in entities)
      {
        if (entity.m_LaneId >= 0 && entity.m_LaneId < m_Lanes.Length && !m_Lanes[entity.m_LaneId].ContainsKey(entity.m_Position))
          m_Lanes[entity.m_LaneId].Add(entity.m_Position, entity);
      }
    }
    public void AddEntity(InteractableMapEntity entity, int lane, int position)
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

    #endregion

  }
}