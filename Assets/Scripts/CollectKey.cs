using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.Instance.AddKey();
            anim.SetTrigger("Collected");
            Destroy(gameObject, 2f);
        }
    }
}
