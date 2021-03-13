using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ChipController : MonoBehaviour
{
    private Rigidbody2D rb;
    // use the turn speed for its rotation scanning
    public float turnSpeed = 30f;
    public float rayDistance = 6f;
    // how fast can it move
    public float moveSpeed = 5f;
    public Transform rayFrom;    // detect ray from here
    public LayerMask dontRayCastOn;  // use this layer stop stop ray testing yourself!
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = turnSpeed;
        Vector3 forward = transform.TransformDirection(Vector3.up) * rayDistance; 
        
      
        // test for any hits
        RaycastHit2D hit = Physics2D.Raycast( rayFrom.position, forward, rayDistance);
        if (hit.collider != null)
        {
            Debug.Log($"Hit {hit.collider.name}");
            // draw red if hit
            Debug.DrawRay( rayFrom.position, forward, Color.red);
        }
        else
        {
           // draws green if no hit
            Debug.DrawRay( rayFrom.position, forward, Color.green);
        }
    }
}
