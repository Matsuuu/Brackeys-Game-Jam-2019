﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject nextWayPoint;
    private bool nextWayPointHasBeenSet = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Eater"))
        {
            StartCoroutine(ChangePlayerWaypoint(other.gameObject));
        }
    }

    IEnumerator ChangePlayerWaypoint(GameObject player)
    {
        
        if (nextWayPointHasBeenSet)
        {
            Debug.Log("Changing target");
            player.GetComponent<Eater>().setTarget(nextWayPoint);
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(1);
            yield return StartCoroutine(ChangePlayerWaypoint(player));
        }
    }

    public void SetNewWaypoint(GameObject waypoint)
    {
        this.nextWayPoint = waypoint;
        this.nextWayPointHasBeenSet = true;
    }
}