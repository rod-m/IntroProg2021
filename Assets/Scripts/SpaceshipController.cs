using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public int changeDirectionTime = 60;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(speed,0);
        if (Time.frameCount % changeDirectionTime == 0)
        {
            Vector2 dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            rb.velocity = Vector2.zero;
            rb.AddForce(dir.normalized * speed, ForceMode2D.Impulse);
        }
        
    }
}


