using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCntrl : MonoBehaviour
{
    private Rigidbody2D rb;
    public int waitForXFrames = 60;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % waitForXFrames == 0)
        {
            // every nth frame...
            Vector2 dir = new Vector2(Random.Range(-10,10), Random.Range(-10,10));
            // velocity needs set to zero so forces are not additive
            rb.velocity = Vector2.zero;
            rb.AddForce(dir.normalized * speed, ForceMode2D.Impulse);
        }
        
    }
}
