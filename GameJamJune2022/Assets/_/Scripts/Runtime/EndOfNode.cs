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
    public TextMeshPro[] m_choices;
    public Color[] m_colors = new Color[4];
    private string[] _arrows = new string[4] { "↑", "←", "→", "↓" };

    private void Awake()
    {
      m_choices = GetComponentsInChildren<TextMeshPro>();
    }

    internal void SetUITextChoices(List<MapNode> mapNodes)
    {
      for(int i = 0; i < m_choices.Length; i++)
      {
        if(i < mapNodes.Count)
        {
          if(i % 2 == 0)
          {
            m_choices[i].text = _arrows[i] + " "  + mapNodes[i].GetChoiceText();
          }
          else
          {
            m_choices[i].text = mapNodes[i].GetChoiceText() + " " + _arrows[i];
          }
          m_choices[i].color = m_colors[i];
        }
        else
        {
          m_choices[i].text = "";
        }

      }
    }
  }
}
