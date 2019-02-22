using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty : MonoBehaviour
{
    public Transform[] waypoints;

    public Transform target;
    public int targetIndex;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetIndex = 0;
        target = waypoints[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (transform.position == target.position)
        {
            if (targetIndex < waypoints.Length - 1)
            {
                targetIndex++;
                target = waypoints[targetIndex];
            }
        }
    }
}
