using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMove2 : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpHeight = 2f;
    public float slidingSpeed = 3f;

    public LayerMask Ground;
    public Transform groundChecker;

    CharacterController con;
    Vector3 moveDirection;
    Vector3 hitNormal;
    Vector3 hitPoint;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundChecker.position, 0.2f, Ground, QueryTriggerInteraction.Ignore);
        isGrounded = (con.collisionFlags & CollisionFlags.Below) != 0;
        if (isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            moveDirection = (new Vector3(h, 0, v)).normalized;
            transform.LookAt(transform.position + moveDirection);
            moveDirection *= moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(-2f * 2 * Physics.gravity.y * jumpHeight);
            }
        }

        moveDirection.y += 2 * Physics.gravity.y * Time.deltaTime;

        Vector3 slidingDirection = Vector3.zero;
        if (Vector3.Angle(hitNormal, Vector3.up) > con.slopeLimit)
        {
            // 1. approximation sliding vector
            //slidingDirection = (new Vector3(hitNormal.x, 0f, hitNormal.z)) * 5f;
            //Debug.DrawRay(hitPoint, slidingDirection, Color.cyan, 3f);

            // 2. accurate sliding vector
            Vector3 c = Vector3.Cross(hitNormal, Vector3.up);
            slidingDirection = Vector3.Cross(hitNormal, c) * slidingSpeed;
            Debug.DrawRay(hitPoint, slidingDirection, Color.green, 3f);
        }

        con.Move((moveDirection + slidingDirection) * Time.deltaTime);
        //con.SimpleMove((moveDirection + slidingDirection));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
        hitPoint = hit.point;
        Debug.DrawRay(hit.point, hit.normal, Color.magenta, 3f);

        var h = hit.gameObject.GetComponent<HealingPlatform>();
        if (h != null)
        {
            GetComponent<HealOverTimeCo>().Heal();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(groundChecker.position, 0.2f);
    }
}

//0 0 0 0 0 0 0 0
//0: None
//1: Sides
//2: Above
//4: Below

// 0 1 1 1  &  1 0