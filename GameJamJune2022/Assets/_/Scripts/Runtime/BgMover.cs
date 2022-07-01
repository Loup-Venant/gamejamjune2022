using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Runtime
{
  public class BgMover : MonoBehaviour
  {
    public GameObject Image1;
    public GameObject Image2;

    private void Update()
    {
      Image1.transform.position -= new Vector3(Time.deltaTime,0 , 0);
      Image2.transform.position -= new Vector3(Time.deltaTime, 0, 0);
      if(Image1.transform.position.x <= -17.75f)
      {
        Image1.transform.position = new Vector3(17.75f , 0 , 0);
      }
      if(Image2.transform.position.x <= -17.75f)
      {
        Image2.transform.position = new Vector3(17.75f , 0 , 0);
      }
    }
  }
}
