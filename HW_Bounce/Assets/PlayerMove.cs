using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Transform mv;

    public float speed = 5.0f;
    void Start()
    {
        mv = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            mv.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mv.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}