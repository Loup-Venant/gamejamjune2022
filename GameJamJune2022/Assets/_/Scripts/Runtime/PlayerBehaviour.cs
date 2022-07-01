using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Logic;
using Gameplay.Sounds;
using Gameplay.Data;

namespace Gameplay.Runtime
{
  public class PlayerBehaviour : MonoBehaviour
  {
    // Player is moving between n number of lanes.
    // Each lane is on a diferrent y height.
    // Player can move between lanes using a joystick or Z and S keys.
    // when player doesn't input anything the player is drifting toward another random lane.

    #region Exposed
    [Header("Player Properties")]
    [SerializeField] private float _speed;

    [SerializeField] private Sprite _maskIdle;
    [SerializeField] private Sprite _maskAngry;

    [Header("Dev DEBUG")]
    public Player m_player;
    
    [SerializeField] private PlayerContainer _player;

    #endregion


    #region Unity API

    private void Awake()
    {
      m_player = new Player();
      _player.m_player = m_player;
            _soundPlayer = GetComponent<SoundPlayer>();

      _rigidbody = GetComponent<Rigidbody2D>();
      _renderer = GetComponent<SpriteRenderer>();
      m_player.ChangeStance();
      ChangeSprite();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< HEAD
      var temp = other.GetComponent<MapEntityBehaviour>();
      temp.HitByPlayer(m_player);
       if(temp.m_mapEntity.GetName().Contains("tem"))
       {
           _soundPlayer.PlayTotem();
       }  
       if(temp.m_mapEntity.GetName().Contains("nemy"))
       {
           _soundPlayer.PlayEnemy();
       }  
       if(temp.m_mapEntity.GetName().Contains("racte"))
       {
           _soundPlayer.PlayAztek();
       }
=======
      if(other.tag == "Interactable")
      {
        other.GetComponent<MapEntityBehaviour>().InteractableHitByPlayer(m_player);
      }
      else if(other.tag == "EndOfNode")
      {
        other.GetComponent<MapEntityBehaviour>().EndOfNodeHitByPlayer(m_player);
      }
>>>>>>> b821c50dac414e5a6d55a4c57f2186d24fb6a052
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

      if(Input.GetButtonDown("ChangeStance"))
      {
        m_player.ChangeStance();
        ChangeSprite();
      }
      
    }

    private void ChangeSprite()
    {
      _renderer.sprite = m_player.m_IsPassive ? _maskIdle : _maskAngry;
    }

    #endregion

    #region Hidden

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
        private SoundPlayer _soundPlayer;

    private SpriteRenderer _renderer;

    #endregion
  }
}
