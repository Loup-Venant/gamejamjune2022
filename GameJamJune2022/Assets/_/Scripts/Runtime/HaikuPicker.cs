using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Data;
using TMPro;

namespace Gameplay.Runtime
{
  public class HaikuPicker : MonoBehaviour
  {
    public List<HaikuContainer> Haikus = new List<HaikuContainer>();

    public string GetHaiku(bool win)
    {
      return Haikus[Random.Range(0, Haikus.Count)].GetHaiku(win);
    }
    private void Start()
    {
      var tmp = GetComponent<TextMeshProUGUI>();
      tmp.text = GetHaiku(true) +"\n\n\n" + tmp.text;
      //Debug.Log(GetHaiku(true));
      //Debug.Log(GetHaiku(true));
      //Debug.Log(GetHaiku(true));
      //Debug.Log(GetHaiku(false));
      //Debug.Log(GetHaiku(false));
    }
  }
}
