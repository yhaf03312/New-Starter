using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStart : MonoBehaviour
{
    private void Start()
    {
        IEnumerator Start()
        {
            print("start");
            yield return StartCoroutine(Todo());
        }

        IEnumerator Todo()
        {
            print("A");
            yield return new WaitForSeconds(1f);
        }
    }

     
    //    IEnumerator update()
    //    {
    //        yield return null;

    //    }
    //}
}