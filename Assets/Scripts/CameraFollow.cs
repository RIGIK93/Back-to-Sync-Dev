using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 1.0f;
        public Vector3 offset;
        public float yLessThan = 0;
        public Vector3 groundOffset;

        private Vector3 targetPos;


        private void Update()
        {
            if (target == null) return;
            if (target.position.y > yLessThan)
                targetPos = target.position + offset;
            else
                targetPos = target.position + groundOffset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
