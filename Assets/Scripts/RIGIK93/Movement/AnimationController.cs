using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RIGIK93
{
    public class AnimationController : Character
    {
        private Animator animator;
        protected override void Initialization()
        {
            base.Initialization();
        }
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            Initialization();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetBool("IsJumping", character.isJumping);
            animator.SetBool("IsGrounded", character.isGrounded);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            if (Mathf.Round(rb.velocity.x)> 0)
            {
                animator.SetInteger("Direction", 1);
                gameObject.transform.localScale = new Vector3(Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y, rb.transform.localScale.z);
            }
            else if (Mathf.Round(rb.velocity.x) == 0)
                animator.SetInteger("Direction", 0);
            else
            {
                animator.SetInteger("Direction", -1);
                gameObject.transform.localScale = new Vector3(Mathf.Abs(rb.transform.localScale.x) * -1, rb.transform.localScale.y, rb.transform.localScale.z);
            }
        }
    }
}
