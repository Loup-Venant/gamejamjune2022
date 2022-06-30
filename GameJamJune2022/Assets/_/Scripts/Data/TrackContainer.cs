using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;
using System;

namespace Gameplay.Data
{
  [CreateAssetMenu(fileName = "New Track", menuName = "Gameplay/Track", order = 1)]
    // Store MapEntities.
    // Each MapEntities knows wich lane it is on.
    // Each MapEntities knows wich position it is on.
    // Each MapEntities knows wich type it is.

    public class TrackContainer : ScriptableObject
    {

      public MapEntityGenerator[] m_Lane0;
      public MapEntityGenerator[] m_Lane1;
      public MapEntityGenerator[] m_Lane2;

    internal List<InteractableMapEntity> GetEntities()
    {
      var returnValue = new List<InteractableMapEntity>();
      for(int i = 0; i < m_Lane0.Length; i++)
      {
        if(m_Lane0[i] != null)
        {
          returnValue.Add(m_Lane0[i].GetEntity(i, 0));
        }
      }
      for(int i = 0; i < m_Lane1.Length; i++)
      {
        if(m_Lane1[i] != null)
          returnValue.Add(m_Lane1[i].GetEntity(i, 1));
      }
      for(int i = 0; i < m_Lane2.Length; i++)
      {
        if(m_Lane2[i] != null)
         returnValue.Add(m_Lane2[i].GetEntity(i, 2));
      }
      return returnValue;
    }
  }
}
