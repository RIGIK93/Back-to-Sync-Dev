using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RIGIK93
{
    public class HorizontalMovement : Character
    {
        public float speed; // speed of the player
        public float distanceToCollider; // distance on which check for walls
        public LayerMask collisionLayer; // walls layer
        [HideInInspector] public bool blockInput = false;

        private float horizontalInput;
        protected override void Initialization()
        {
            base.Initialization();
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
                GatherInput();
            else
                horizontalInput = 0f;
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
            SpeedModifier();
        }
        void GatherInput() {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        void SpeedModifier()
        {
            if ((rb.velocity.x > 0 && collisionCheck(Vector2.right, distanceToCollider, collisionLayer)) || (rb.velocity.x < 0 && collisionCheck(Vector2.left, distanceToCollider, collisionLayer)))
                rb.velocity = new Vector2(.01f, rb.velocity.y);
        }
    }
}
