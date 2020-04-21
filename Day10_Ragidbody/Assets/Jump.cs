using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.up * 400f);
        // F = ma = (0, 400, 0)
        // a = F / m
        // v(i+1) = v(i) + a(i1)*dt   : dt = 0.02 = Time.fixed DealtaTime
        // p(i+1) = p(i) + v(i+1)*dt

        //
    }
}
