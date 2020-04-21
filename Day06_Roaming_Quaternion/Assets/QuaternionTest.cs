using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0f, 50f, 0f);
        print(Mathf.Approximately(transform.eulerAngles.y, 50f));

        transform.rotation *= Quaternion.Euler(0f, 100f, 0f); // 누적

        transform.rotation = Quaternion.Euler(0f, 100f, 0f);
        print(Mathf.Approximately(transform.eulerAngles.y, 100f));
        transform.Rotate(Vector3.up * 90f);
        print(transform.eulerAngles.y);
        print(Mathf.Approximately(transform.eulerAngles.y, 190f)); //  190 == 190-360 == -170f

        //transform.Rotate(Vector3.up, 90f); next ==
        transform.rotation *= Quaternion.AngleAxis(90f, Vector3.up);
        print(Mathf.Approximately(transform.eulerAngles.y, 200f));

        transform.rotation = Quaternion.identity; // 회전하지않은 상태
        print(Mathf.Approximately(transform.eulerAngles.x, 0f));
        print(Mathf.Approximately(transform.eulerAngles.y, 0f));
        print(Mathf.Approximately(transform.eulerAngles.z, 0f));

        transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
        print(Mathf.Approximately(transform.eulerAngles.x, 90f));

        transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
        print(Mathf.Approximately(transform.eulerAngles.y, 90f));
        transform.rotation = Quaternion.LookRotation(Vector3.right);
        print(Mathf.Approximately(transform.eulerAngles.y, 90f));

        var q1 = Quaternion.Euler(0f, -45f, 0f);
        var q2 = Quaternion.Euler(0f, 45f, 0f);
        print(Mathf.Approximately(Quaternion.Angle(q1, q2), 90f));







    }
}

 