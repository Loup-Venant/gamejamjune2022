namespace Gameplay.Logic
{
  public abstract class MapEntity
  {
    public int m_LaneId;
    public int m_Position;
    public int m_Value;

    public abstract string GetName();
  }
  public abstract class InteractableMapEntity : MapEntity
  {
    public void Choose(Player player, bool choice)
    {
      if (choice)
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
  public class Item : InteractableMapEntity
  {
    public override string GetName()
    {
      return "Item";
    }

    protected override void ActOnIt(Player player)
    {
      player.AddItemValue(m_Value);
    }

    protected override void NotActOnIt(Player player)
    {
      player.AddFame(m_Value);
    }
  }
  public class Character : InteractableMapEntity
  {
    protected override void ActOnIt(Player player)
    {
      player.AddFame(m_Value / 2);
      player.AddItemValue(-m_Value / 2);
    }

    protected override void NotActOnIt(Player player)
    {

    }
    public override string GetName()
    {
      return "Character";
    }
  }
  public class Enemy : InteractableMapEntity
  {
    protected override void ActOnIt(Player player)
    {
      player.AddSacrifice(m_Value);
    }

    protected override void NotActOnIt(Player player)
    {
      player.AddFame(m_Value);
    }
    public override string GetName()
    {
      return "Enemy";
    }
  }
  public class EndNodeEntity : MapEntity
  {
    private string _nodeName;

    public EndNodeEntity(string name, int position)
    {
      _nodeName = name;
      m_Position = position;
      m_LaneId = -1;
      m_Value = 0;
    }
    public override string GetName()
    {
      return _nodeName;
    }
  }
}