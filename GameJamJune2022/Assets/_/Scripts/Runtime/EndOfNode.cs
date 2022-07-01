using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Logic;
using UnityEngine;
using TMPro;

namespace Gameplay.Runtime
{
  public class EndOfNode : MonoBehaviour
  {
    [Header("Dev DEBUG")]
    public TextMeshProUGUI[] m_choices;

    internal void SetUITextChoices(List<MapNode> mapNodes)
    {
      for(int i = 0; i < m_choices.Length; i++)
      {
        if(i < mapNodes.Count)
        {
          m_choices[i].text = mapNodes[i].GetChoiceText();
        }

      }
    }
  }
}
