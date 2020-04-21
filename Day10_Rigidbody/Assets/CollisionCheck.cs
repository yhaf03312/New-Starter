using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter: " + gameObject.name + " vs. " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter: " + gameObject.name + " vs. " + other.gameObject.name);
    }
}
