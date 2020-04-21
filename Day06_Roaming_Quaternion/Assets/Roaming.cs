using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : MonoBehaviour
{
    public Transform wayPointsRoot;
    public float speed = 2;
    int n = 0;
    Vector3 nextPoint;

    List<Transform> wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = new List<Transform>();
        foreach (Transform t in wayPointsRoot)
            wayPoints.Add(t);

        nextPoint = wayPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, nextPoint) > 0.2f)
        {
            Vector3 dir = nextPoint - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime); // 등속
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);

            //transform.position = Vector3.Slerp(transform.position, nextPoint, speed * Time.deltaTime / dir.magnitude); //등속

            //transform.position = Vector3.Lerp(transform.position, wayPoints[0].position, speed * Time.deltaTime); // 등가속도
            //transform.position = Vector3.Lerp(transform.position, wayPoints[0].position, speed * Time.deltaTime / dir.magnitude); //등속
            //transform.position = transform.position + dir.normalized * speed * Time.deltaTime; // 등속
            //transform.Translate(dir.normalized * 4 * speed * Time.deltaTime, Space.World); //등속 (주체 : 월드 )

            //transform.LookAt(nextPoint);
            //transform.Rotate(Vector3.up * Vector3.Angle(transform.forward, dir));
            //transform.Rotate(Vector3.up * SignedAngle(transform.forward, dir, Vector3.up) * 10f * Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 5f); //등각속도
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);


        } else
        {
            n++;
            n %= wayPoints.Count;
            nextPoint = wayPoints[n].transform.position;
            // change dest.
            // %
        }
    }
}
