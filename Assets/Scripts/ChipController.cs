using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class ChipController : MonoBehaviour
{
    public enum ChipStates {SCAN, CLEAN}
    public ChipStates chipstate = ChipStates.SCAN;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (chipstate)
        {
            case ChipStates.SCAN:
                Scan();
                break;
            case ChipStates.CLEAN:
                Clean();
                break;
        }

        
    }

    void Clean()
    {
        rb.AddForce(transform.up * (moveSpeed * Time.fixedDeltaTime));
        if(rb.velocity.magnitude > moveSpeed)
            rb.velocity = rb.velocity.normalized * moveSpeed;
        
        Debug.DrawRay( rayFrom.position, transform.up * rayDistance, Color.white);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // is it a virus?
        if (other.CompareTag("virus"))
        {
            // find where on the grid this is
            Vector3Int position = grid.WorldToCell(rayFrom.position); 
            tilemap.SetTile(position, null); // set tile at this position as null
            rb.velocity = Vector2.zero; // stop any movement
            chipstate = ChipStates.SCAN; // resume scan
        }
    }
 
    void Scan()
    {
        rb.angularVelocity = turnSpeed;
        Vector3 forward = transform.TransformDirection(Vector3.up) * rayDistance;
        rb.velocity = transform.up * 0.3f;
        // test for any hits
        RaycastHit2D hit = Physics2D.Raycast( rayFrom.position, forward, rayDistance, rayCastOn);
        if (hit.collider != null)
        {
            Debug.Log($"Hit {hit.collider.name}");
            // draw red if hit
            Debug.DrawRay( rayFrom.position, forward, Color.red);
            rb.angularVelocity = 0;
            chipstate = ChipStates.CLEAN;
        }
        else
        {
            // draws green if no hit
            Debug.DrawRay( rayFrom.position, forward, Color.green);
        }
    }
}
