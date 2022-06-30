using System;

namespace Gameplay.Logic
{
  public enum PlayerStat
  {
    Money,
    Fame,
    GodFavor,
    Time
  }
  public class Player
  {
    public int m_Blood
    {
      get;
      private set;
    }
    public int m_Time
    {
      get;
      private set;
    }
    public int m_Value
    {
      get; 
      private set;
    }
    public int m_Fame
    {
      get; 
      private set;
    }
    public int m_Position
    {
      get; 
      private set;
    }
    public bool m_IsPassive 
    { 
      get; 
      private set;
    }
    public void ChangeStance()
    {
      m_IsPassive = !m_IsPassive;
    }
    public void Move()
    {
      m_Position++;
    }

    internal void AddFame(int value)
    {
      m_Fame += value;
    }

    internal void AddItemValue(int value)
    {
      m_Value += value;
    }

    internal void AddSacrifice(int value)
    {
      m_Blood += value;
    }
  }
}