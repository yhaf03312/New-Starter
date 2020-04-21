using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(TripleJumpAttck());
    }

    IEnumerator TripleJumpAttck()
    {
        Jump(3f);
        yield return new WaitForSeconds(1.8f);
        Jump(3f);
        yield return new WaitForSeconds(1.8f);
        yield return WheelWindJump(3f);

    }

    IEnumerator WheelWindJump(float height)
    {
        var rb = GetComponent<Rigidbody>();
        Vector3 v = rb.velocity;
        v.y = Mathf.Sqrt(2.0f * 9.8f * height);
        rb.velocity = v;
        rb.maxAngularVelocity = 100f;
        rb.angularVelocity = Vector3.up * 15f;

        yield return new WaitForSeconds(2f);
        rb.angularDrag = 2f;
    

        while(true)
        {
            print(rb.angularVelocity.magnitude);
            if (rb.angularVelocity.magnitude < 1)
                break;
            yield return null;
        }
        rb.angularVelocity = Vector3.zero;

        rb.maxAngularVelocity = 7;
        rb.angularDrag = 0.05f;
    }

    private void Jump(float height)
    {
        var rb = GetComponent<Rigidbody>();
        Vector3 v = rb.velocity;
        v.y = Mathf.Sqrt(2.0f * 9.8f * height);
        rb.velocity = v;
        print("Jump");
    }

 }

