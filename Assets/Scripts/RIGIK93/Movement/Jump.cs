using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RIGIK93
{
    public class Jump : Character
    {
        public int maxJumps;
        public float jumpForce;
        public float maxButtonHoldTime;
        public float holdForce;
        public float distanceToCollider;
        public float maxJumpSpeed;
        public float maxFallSpeed;
        public float fallSpeed;
        public float gravityMultiplier;
        public LayerMask collisionLayer;

        private bool jumpPressed;
        private bool jumpHeld;
        private float buttonHoldTime;
        private float originalGravity;
        private int numberOfJumpsLeft;
        [HideInInspector] public bool blockInput = false;


        protected override void Initialization()
        {
            base.Initialization();
            buttonHoldTime = maxButtonHoldTime;
            originalGravity = rb.gravityScale;
            numberOfJumpsLeft = maxJumps;
        }
        // Start is called before the first frame update
        void Start()
        {
            Initialization();
        }

        // Update is called once per frame
        void Update()
        {
            if (!blockInput)
                ProcessInput();
            else {
                jumpHeld = false;
                jumpPressed = false;
            }
            CheckForJump();
            GroundCheck();
        }

        void ProcessInput()
        {
            if (Input.GetButtonDown("Jump"))
                jumpPressed = true;
            else
                jumpPressed = false;
            if (Input.GetButton("Jump"))
                jumpHeld = true;
            else
                jumpHeld = false;
        }

        private void FixedUpdate()
        {
            PerformJump();
        }

        private void CheckForJump()
        {
            if (jumpPressed) {
                if (!character.isGrounded && numberOfJumpsLeft == maxJumps)
                {
                    character.isJumping = false;
                    return;
                }
                numberOfJumpsLeft--;
                if (numberOfJumpsLeft >= 0)
                {
                    rb.gravityScale = originalGravity;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    buttonHoldTime = maxButtonHoldTime;
                    character.isJumping = true;
                }
            }
        }

        private void PerformJump()
        {
            if (character.isJumping)
            {
                rb.AddForce(Vector2.up * jumpForce);
                AdditionalAir();
            }
            if (rb.velocity.y > maxJumpSpeed)
                rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
            Falling();
        }

        private void AdditionalAir()
        {
            if (!jumpHeld)
            {
                character.isJumping = false;
                return;
            }

            buttonHoldTime -= Time.fixedDeltaTime;
            if (buttonHoldTime <= 0)
            {
                buttonHoldTime = 0;
                character.isJumping = false;
            }
            else
                rb.AddForce(Vector2.up * holdForce);
        }

        private void Falling()
        {
            if (!character.isJumping && rb.velocity.y < fallSpeed)
                rb.gravityScale = gravityMultiplier;
            // aborting jump instantly adds feel of control
            if (!character.isJumping && !jumpHeld && rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            if (rb.velocity.y < maxFallSpeed)
                rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }

        private void GroundCheck()
        {
            if (collisionCheck(Vector2.down, distanceToCollider, collisionLayer) && !character.isJumping)
            {
                character.isGrounded = true;
                numberOfJumpsLeft = maxJumps;
                rb.gravityScale = originalGravity;
            }
            else
                character.isGrounded = false;
        }
    }
}
