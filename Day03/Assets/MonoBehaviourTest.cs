using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourTest : MonoBehaviour
{
    private void Awake()
    {
        print("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        print(name == "SomeTest");
        print(gameObject.name == name);
        print(transform == gameObject.transform);
        print(transform == GetComponent<Transform>());
        print(GetComponent<MonoBehaviourTest>() == this);
        print(gameObject.GetComponent<MonoBehaviourTest>() == this); 

        print("Start");
    }

    // Update is called once per frame
    void Update()
    {

        print("Update");

        
    }

    private void FixedUpdate()
    {
        print("FixedUpdate");
    }

    private void LateUpdate()
    {
        print("LateUpdate");
    }
}
