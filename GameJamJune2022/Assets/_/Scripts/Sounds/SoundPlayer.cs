using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Sounds
{
    public class SoundPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        public AudioSource TotemSound;
        public AudioSource AztekSound;
        public AudioSource EnemySound;

        public void PlayTotem()
        {
            TotemSound.Play();
        }
        public void PlayEnemy()
        {
            EnemySound.Play();
        }
        public void PlayAztek()
        {
            AztekSound.Play();
        }
    } 
}
