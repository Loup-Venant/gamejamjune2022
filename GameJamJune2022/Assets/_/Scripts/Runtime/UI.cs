using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;

namespace Gameplay.Runtime
{
    public class UI : MonoBehaviour
    {
      // Show Debug of player values in the UI : Blood, Time, Value, Fame, Position, IsPassive

      #region Exposed

      [Header("Dev DEBUG")]
      [SerializeField] private Player _player;

      #endregion

      
      #region Unity API

      private void OnGUI()
      {
        GUI.Label(new Rect(10, 10, 200, 20), "Blood: " + _player.m_Blood);
        GUI.Label(new Rect(10, 30, 200, 20), "Time: " + _player.m_Time);
        GUI.Label(new Rect(10, 50, 200, 20), "Value: " + _player.m_Value);
        GUI.Label(new Rect(10, 70, 200, 20), "Fame: " + _player.m_Fame);
        GUI.Label(new Rect(10, 90, 200, 20), "Position: " + _player.m_Position);
        GUI.Label(new Rect(10, 110, 200, 20), "IsPassive: " + _player.m_IsPassive);
      }

      #endregion
    }
}
