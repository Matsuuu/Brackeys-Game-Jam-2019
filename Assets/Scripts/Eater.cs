using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eater : MonoBehaviour
{
    public GameObject target;
    public GameObject food;

    public bool isMoving;

    private float startMovespeed;
    public float moveSpeed;

    public int moveSpeedIncreaseDistance;
    // Start is called before the first frame update
    void Start()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        startMovespeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleSpeed();
    }

    private void HandleMovement()
    {
        if (isMoving)
        {
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Waypoint");
            }
            transform.parent.transform.position =
                Vector2.MoveTowards(transform.parent.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void HandleSpeed()
    {
        if (Vector3.Distance(transform.position, food.transform.position) < moveSpeedIncreaseDistance)
        {
            moveSpeed = startMovespeed * 1.25f;
        }
        else
        {
            moveSpeed = startMovespeed;
        }
    }

    public void setTarget(GameObject go)
    {
        this.target = go;
    }

}
