using System.Collections;
using System.Collections.Generic;

namespace Gameplay.Logic
{
  public class Map
  {
    public static int NumberOfLanes;
    Dictionary<int, MapEntity>[] m_Lanes;
    Dictionary<int, Decision> m_History;
    public Map()
    {
      m_Lanes = new Dictionary<int, MapEntity>[NumberOfLanes];
      m_History = new Dictionary<int, Decision>();
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
}