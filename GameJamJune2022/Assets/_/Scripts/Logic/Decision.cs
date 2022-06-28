namespace Gameplay.Logic
{
  public struct Decision
  {
    int Lane;
    MapEntity Entity;
    bool Choice;

    public Decision(int lane)
    {
      Lane = lane;
      Entity = null;
      Choice = false;
    }
    public Decision(int lane, MapEntity entity, bool choice) 
    {
      Lane = lane;
      Entity = entity;
      Choice = choice;
    }
  }
}