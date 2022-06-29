using System;

namespace Gameplay.Logic
{
  public class Player
  {
    public int m_Value
    {
      get; private set;
    }
    public int m_Fame
    {
      get; private set;
    }
    public int m_Position
    {
      get; private set;
    }
    public bool m_IsPassive { get; private set; }
    public void ChangeStance()
    {
      m_IsPassive = !m_IsPassive;
    }
    public void Move()
    {
      m_Position++;
    }

    internal void AddItemFame(int fame)
    {
      m_Value += fame;

    }

    internal void AddItemValue(int value)
    {
      m_Value += value;
    }
  }
}