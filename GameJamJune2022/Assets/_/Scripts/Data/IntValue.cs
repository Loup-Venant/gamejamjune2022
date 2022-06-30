using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Data
{
    [CreateAssetMenu(fileName = "New IntValue", menuName = "Gameplay/IntValue", order = 1)]
    public class IntValue : ScriptableObject
    {
      public int m_value;
    }
}
