using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpHeight = 2f;
    public LayerMask groundMask;
    public Transform groundChecker;

    Rigidbody rb;
    [SerializeField]
    bool isGrounded = false;
    RaycastHit hit;
    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Physics.Raycast()
        // 2. Physics.CheckSphere()
        isGrounded = Physics.SphereCast(groundChecker.position,
                                        0.5f,
                                        -transform.up,
                                        out hit,
                                        0.2f,
                                        groundMask,
                                        QueryTriggerInteraction.Ignore);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpHeight);
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDirection = (new Vector3(h, 0, v).normalized);
        moveDirection *= moveSpeed;
        transform.LookAt(transform.position + moveDirection);
    }

    private void Jump(float jumpHeight)
    {
        rb.velocity = Vector3.up * Mathf.Sqrt(-2f * 0.5f*Physics.gravity.y * jumpHeight);
    }

    private void FixedUpdate()
    {
        Vector3 move = moveDirection * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(groundChecker.position, 0.5f);
    }
}
