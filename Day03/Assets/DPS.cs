using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform root;

    void Start()
    {
        iterativeDFS(root, print);
    }

    void iterativeDFS(Transform root, Action<Transform> callback)
    {
        var stack = new Stack<Transform>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var t = stack.Pop();
            callback(t);
            for (int i = t.childCount - 1; i >= 0; i--)
                stack.Push(t.GetChild(i));
        }
    }
}
