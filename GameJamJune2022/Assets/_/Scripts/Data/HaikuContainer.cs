using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Data
{
  public class HaikuContainer : ScriptableObject
  {
    public List<string> HaikuParts = new List<string>();
    public string HaikuEndWin;
    public string HaikuEndLoss;
    public List<string> randomPart;

    public string GetHaiku(bool win)
    {
      var index = Random.Range(0, HaikuParts.Count);
      var retVal = HaikuParts[index];
      HaikuParts.RemoveAt(index);
      while (HaikuParts.Count > 0)
      {
        retVal += "\n" + HaikuParts[index];
        HaikuParts.RemoveAt(index);
      }
      retVal += "\n";
      retVal += win ? HaikuEndWin : HaikuEndLoss;
      return retVal;
    }
  }
}
