using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Runtime
{
    public class Mover : MonoBehaviour
    {
        //move Map Entity to the left until it reaches a certain distance
        //when it reaches that distance, it is destroyed

        #region Exposed

        [Header ("Mover Properties")]

        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _destroyDistance = 10f;

        #endregion
        
        #region Unity API

        private void Update()
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            if (transform.position.x < -_destroyDistance)
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}