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
      player.AddFame(m_Value);
    }
  }
  public class Character : MapEntity
  {
    protected override void ActOnIt(Player player)
    {
      player.AddFame(m_Value/2);
      player.AddItemValue(-m_Value/2);
    }

    protected override void NotActOnIt(Player player)
    {
      
    }
  }
  public class Ennemy : MapEntity
  {
    protected override void ActOnIt(Player player)
    {
      player.AddSacrifice(m_Value);
    }

    protected override void NotActOnIt(Player player)
    {
      player.AddFame(m_Value);
    }
  }
}