using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;

namespace Gameplay.Data
{
[CreateAssetMenu(fileName = "PlayerContainer", menuName = "Gameplay/PlayerContainer", order = 1)]
  public class PlayerContainer : ScriptableObject
  {
    public Player m_player;
  }
}
