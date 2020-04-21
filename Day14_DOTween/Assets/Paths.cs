using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Paths : MonoBehaviour
{
    public Transform target;

    public Vector3[] wayPoints = new[]

    {
        new Vector3(4, 2, 6),
        new Vector3(8, 6, 14),
        new Vector3(4, 2, 14),
        new Vector3(0, 2, 6),
        new Vector3(-3, 2, 6)
    };


    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        target.DOPath(wayPoints, 4f, PathType.CatmullRom).SetOptions(true).SetLookAt(5f).SetLoops(-1);
        T.SetEase(Ease.Linear);//

    }
}
