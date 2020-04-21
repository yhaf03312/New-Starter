using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = new Vector3(1f, 1f, 1f);
        Vector3 u = new Vector3(1f, 1f, 1f);

        print(v == u);
        print(2 * v == new Vector3(2f, 2f, 2f));
        v = new Vector3(1f, 0f, 0f);
        print(v == Vector3.right);
        print(v.magnitude == 1f);
        print(Vector3.one.magnitude); // root(3) = 1.732051f
        print(v.ToString() == "1.0, 0.0 0.0");
        print(v);
        print(Vector3.Distance(Vector3.zero, u) == u.magnitude);
        print(Vector3.Angle(Vector3.right, Vector3.up) == 90f);
        print(Vector3.Angle(Vector3.right, Vector3.forward) == 90f);
        print((2 * Vector3.up).normalized == Vector3.up);
        Vector3 up2 = 2 * Vector3.up;
        print(up2 / up2.magnitude == Vector3.up); //up2.normalized
        print(Vector3.Dot(Vector3.right, Vector3.up) == 0);
        print(Vector3.Dot(Vector3.right, Vector3.right) == 1);

        print(Vector3.Cross(Vector3.right, Vector3.up) == Vector3.forward);
        print(Vector3.Cross(Vector3.up, Vector3.right) == -Vector3.forward);

    }

}
