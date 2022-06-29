namespace Gameplay.Logic
{
  public abstract class MapEntity
  {
    public int m_LaneId;
    public int m_Position;
    public int m_Value;
    public void Choose(Player player, bool choice)
    {
      if(choice)
      {
        ActOnIt(player);
      }
      else
      {
        NotActOnIt(player);
      }
    }
    protected abstract void ActOnIt(Player player);
    protected abstract void NotActOnIt(Player player);
  }
  public class Item : MapEntity
  {
    protected override void ActOnIt(Player player)
    {
      player.AddItemValue(m_Value);
    }

    protected override void NotActOnIt(Player player)
    {
      player.AddItemFame(m_Value);
    }
  }
  public class Character : MapEntity
  {
    protected override void ActOnIt(Player player)
    {
      throw new System.NotImplementedException();
    }

    protected override void NotActOnIt(Player player)
    {
      throw new System.NotImplementedException();
    }
  }
}