using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
    public class ChipPlayerController : MonoBehaviour
    {
        /*
         * I want to create a similar controller to the NPC Chip
         * This should move the same way, except controlled by WASD
         * Also need to shoot to destroy the Chip before it gets virus score before you
         * You also can clean virus, the aim is to do it faster than NPC
         * 
         */
       private Rigidbody2D rb;
        // use the turn speed for its rotation scanning
        public float turnSpeed = 30f;
        public float rayDistance = 6f;
        // how fast can it move
        public float moveSpeed = 5f;
        public Transform rayFrom;    // detect ray from here
        public LayerMask rayCastOn;  // raycast on this layer!
        public Grid grid;
        public Tilemap tilemap;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float turn = 0f;
            if (Input.GetKey(KeyCode.A))
            {
                turn = -turnSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                turn = turnSpeed;
            }
            rb.angularVelocity = turn;
           // Vector3 forward = transform.TransformDirection(Vector3.up) * rayDistance;
            //rb.velocity = transform.up * 0.3f;
        }
    }
