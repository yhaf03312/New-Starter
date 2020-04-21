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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 400f);         // dynamics  vs. kinematic
            // F = ma = (0, 400, 0)
            // a = F / m = G = ( 0, -9.8, 0)
            // v(i+1) = v(i) + a(i+1)*dt     : dt = 0.02 = Time.fixedDeltaTime = t(i+1)-t(i)
            // p(i+1) = p(i) + v(i+1)*dt

            // a = (v(i+1) - v(i)) / dt
            // v = (p(i+1) - p(i)) / dt

            // p(i+1) = p(i) + (v(i) + F / m * dt) * dt


            //Vector3 v = rb.velocity;
            //v.y = Mathf.Sqrt(-2 * Physics.gravity.y * 3);
            //rb.velocity = v;
        }
    }
}
