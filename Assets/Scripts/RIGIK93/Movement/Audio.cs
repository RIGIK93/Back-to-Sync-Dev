using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RIGIK93
{
    public class Audio : Character
    {
        private AudioManager manager;
        [SerializeField] private AudioClip walkSound;

        protected override void Initialization()
        {
            base.Initialization();
            manager = GetComponent<AudioManager>();
        }
        private void Start()
        {
            Initialization();
        }

        private void Update()
        {
            if (character.isGrounded && !manager.isPlaying() && Mathf.Abs(rb.velocity.x) > .01f)
            {
                manager.unPause();
                if (!manager.isPlaying())
                    manager.Play(walkSound);
            } else if (manager.isPlaying() && (!character.isGrounded || Mathf.Abs(rb.velocity.x) <= .01f))
            {
                manager.Pause();
            }
        }
    }
}
