using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Data
{
  [CreateAssetMenu(menuName = "Gameplay/Haiku")]
  public class HaikuContainer : ScriptableObject
  {
    public List<string> HaikuParts = new List<string>();
    public string HaikuEndWin;
    public string HaikuEndLoss;
    public List<string> randomPart =new List<string>();

    public string GetHaiku(bool win)
    {
      var list = new List<string>();
      list.AddRange(HaikuParts);
      if (randomPart.Count > 0)
        list.Add(randomPart[Random.Range(0, randomPart.Count)]);
      var index = Random.Range(0, list.Count);
      var retVal = list[index];
      list.RemoveAt(index);
      while (list.Count > 0)
      {
        index = Random.Range(0, list.Count);
        retVal += "\n" + list[index];
        list.RemoveAt(index);
      }
      retVal += "\n";
      retVal += win ? HaikuEndWin : HaikuEndLoss;
      return retVal;
    }
  }
}
