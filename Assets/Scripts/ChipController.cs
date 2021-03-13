using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ChipController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float turnSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = turnSpeed;
        
        Vector3 forward = transform.TransformDirection(Vector3.up) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
