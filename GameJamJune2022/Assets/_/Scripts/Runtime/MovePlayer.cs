using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Runtime
{
    public class MovePlayer : MonoBehaviour
    {
      // Player is moving between n number of lanes.
      // Each lane is on a diferrent y height.
      // Player can move between lanes using a joystick or Z and S keys.
      // when player doesn't input anything the player is drifting toward another random lane.

      #region Exposed
      
      [SerializeField] private float _speed;
      Transform _targetPosition;

      #endregion

      #region Unity API

      private void Awake()
      {
       _rigidbody = GetComponent<Rigidbody2D>();
      }

      private void Update()
      {
        GetOffset();
        GetInput();
      }

      private void FixedUpdate()
      {
        Move();
      }


      #endregion


      #region Main

      private void Move()
      {
        _rigidbody.AddForce(_direction * _speed, ForceMode2D.Force);
      }
        private void GetOffset()
      {
        
      }

      private void GetInput()
      {
        float vertical = Input.GetAxis("Vertical");

        
        _direction = new Vector2(0, vertical);
        Debug.Log(_direction);
      }

      #endregion

      #region Hidden

      private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        #endregion
    }
}
