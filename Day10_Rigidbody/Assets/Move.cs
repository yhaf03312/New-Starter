using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
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
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        h *= rotationSpeed * Time.deltaTime;
        v *= speed * Time.deltaTime;

        transform.Translate(Vector3.forward * v);
        transform.Rotate(Vector3.up * h);
    }
}
