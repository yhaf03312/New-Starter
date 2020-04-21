using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{

    public float moveSpeed = 5f;




    // Start is called before the first frame update
    void Start()

    {




    }

    // Update is called once per frame
    void Update()
    {

        //GetAxis()     -1 ~ 1 (float)
        //GetAxisRaw()  -1 , 0 , 1


        //float h = Input.GetAxis("Horizontal");    // -1 ~ 1 (float)
        //float v = Input.GetAxis("Vertical");      // -1 ~ 1 (float)

        float h = Input.GetAxisRaw("Horizontal");    // -1 , 0 , 1
        float v = Input.GetAxisRaw("Vertical");     // -1 , 0 , 1

        //print(h +", " + v);

        Vector3 move = new Vector3(h, 0, v);
        move = move.normalized;
        move *= moveSpeed * Time.deltaTime;
        transform.Translate(move);

        print(move);

        //h *= moveSpeed * Time.deltaTime;
        //v *= moveSpeed * Time.deltaTime;

        ////print(h)
        //transform.Translate(Vector3.right * h);
        //transform.Translate(Vector3.forward * v);

    }
}
