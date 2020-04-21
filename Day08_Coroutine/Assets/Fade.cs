using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    MeshRenderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(FadeIn());
        }

        IEnumerator FadeIn()
        {
            Color c = renderer.material.color;
            for(float f = 1f; f>= 0; f -= 0.01f)
            {
                c.a = f;
                renderer.material.color = c;
                yield return null; // 한프레임을 쉬고 리턴한다. 
                //yield return new WaitForSeconds(Time.deltaTime); // yield return null == 

                

            }
            //yield return null;

        }

        
    }
}
