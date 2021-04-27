using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (GameController.Instance.UseKey())
            {
                Destroy(gameObject); // has key, open door, can be animation!
            }
        }
    }
}
