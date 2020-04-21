using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade0 : MonoBehaviour
{
    bool fadeIn = false;
    MeshRenderer render;
    float alpha = 1.0f; // 0 ~ 1f


    void Start()
    {
        render = GetComponent<MeshRenderer>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !fadeIn)
        {
            fadeIn = true;
            alpha = 1.0f;
        }

        if (fadeIn && alpha > 0f)
        {
            Color c = render.material.color;
            alpha -= 0.01f;
            c.a = alpha;
            render.material.color = c;

            if (alpha < 0f)
            {
                fadeIn = false;
            }
        }
    }
}
