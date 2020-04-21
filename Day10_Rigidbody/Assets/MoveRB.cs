using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRB : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 180f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        h *= rotationSpeed * Time.fixedDeltaTime;       // 0.02f
        v *= speed * Time.fixedDeltaTime;

        // Vector3.forward(0,0,1) vs. transform.forward
        rb.MovePosition(transform.position + transform.forward * v);
        rb.MoveRotation(transform.rotation * Quaternion.Euler(Vector3.up * h));
    }
}
