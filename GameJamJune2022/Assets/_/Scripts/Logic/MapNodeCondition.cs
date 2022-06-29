using System;

namespace Gameplay.Logic
{
  public interface ICondition
  {
    public bool Evaluate();
  }
  public struct MapNodeCondition<T> : ICondition where T : IComparable, IEquatable<T>
  {
    private bool isLower;
    private bool isEqual;
    private T valueReference;
    private Func<T> valueGetter;
    public MapNodeCondition(T valueRef, bool equal, bool lower, Func<T> getter)
    {
      valueReference = valueRef;
      isEqual = equal;
      isLower = lower;
      valueGetter = getter;
    }

    public bool Evaluate()
    {
      var value = valueGetter.Invoke();
      var retval = false;
      if (isEqual)
        retval = value.Equals(valueReference);
      if (isLower)
        retval |= value.CompareTo(valueReference) == -1;
      return retval;
    }
  }
}