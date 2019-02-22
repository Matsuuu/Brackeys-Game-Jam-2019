using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float emissionRate;
    public GameObject waypoint;
    public GameObject lastWaypoint;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject startingWaypoint = Instantiate(waypoint, transform.position, transform.rotation);
        GameObject.FindGameObjectWithTag("Eater").GetComponent<Eater>().setTarget(startingWaypoint);
        lastWaypoint = startingWaypoint;
        StartCoroutine(CreateWaypoints());
    }

    IEnumerator CreateWaypoints()
    {
        GameObject newWayPoint = Instantiate(waypoint, transform.position, transform.rotation);
        lastWaypoint.GetComponent<Waypoint>().SetNewWaypoint(newWayPoint);
        lastWaypoint = newWayPoint;
        yield return new WaitForSeconds(emissionRate);
        yield return StartCoroutine(CreateWaypoints());
    }
}
