using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RIGIK93
{
    public class Character : MonoBehaviour
    {
        protected Rigidbody2D rb;
        protected Collider2D col;
        protected Character character;

        [HideInInspector]
        public bool isGrounded;

        [HideInInspector]
        public bool isJumping;

        private void Start()
        {
            Initialization();
        }


        protected virtual void Initialization()
        {
            character = GetComponent<Character>();
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
        }

        protected virtual bool collisionCheck(Vector2 direction, float distance, LayerMask collision)
        {
            RaycastHit2D[] hits = new RaycastHit2D[10];
            int numHits = col.Cast(direction, hits, distance);
            for (int i = 0; i < numHits; i++)
                if ((1 << hits[i].collider.gameObject.layer & collision) != 0)
                    return true;
            return false;
        }
    }
}
