using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float speed = 5f;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            float interpolation = speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position+offset, interpolation);
        }
    }
}
