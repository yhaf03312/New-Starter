using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public float angle = 90f;
    private bool isRotating;

    //public float duration = 1f;

    float remainingAngle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotating = true;
            remainingAngle = angle;
        }

        if (isRotating)
        {
            float anglePerFrame = angle * Time.deltaTime;       // 90 * (1/60)

            transform.Rotate(Vector3.up * anglePerFrame);

            //isRotating = false;
        }
    }
}
