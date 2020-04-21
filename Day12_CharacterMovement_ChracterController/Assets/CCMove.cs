using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpHeight = 2f;
    public float slidingSpeed = 3f;

    CharacterController con;
    Vector3 moveDirection;
    Vector3 hitNormal;
    Vector3 hitPoint;

    

    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (con.isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            moveDirection = (new Vector3(h, 0, v)).normalized;
            transform.LookAt(transform.position + moveDirection);
            moveDirection *= moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(-2f * 2*Physics.gravity.y * jumpHeight);
            }
        }

        moveDirection.y += 2*Physics.gravity.y * Time.deltaTime;

        Vector3 slidingDirection = Vector3.zero;
        if (Vector3.Angle(hitNormal, Vector3.up) > con.slopeLimit)
        {
            // 1. approximation sliding vector
            //slidingDirection = (new Vector3(hitNormal.x, 0f, hitNormal.z)) * 5f;
            //Debug.DrawRay(hitPoint, slidingDirection, Color.cyan, 3f);

            // 2. accurate sliding vector
            // H/W
            // slidingDirection = sliding * slidingSpeed;
        }

        print( con.Move((moveDirection + slidingDirection) * Time.deltaTime) );
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
        hitPoint = hit.point;
        Debug.DrawRay(hit.point, hit.normal, Color.magenta, 3f);
    }
}

//0 0 0 0 0 0 0 0
//0: None
//1: Sides
//2: Above
//4: Below

// 0 1 1 1  &  1 0