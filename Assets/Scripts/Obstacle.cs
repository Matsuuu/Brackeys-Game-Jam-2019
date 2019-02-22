using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float yAxis;

    private PointSystem PS;

    private GameObject camera;

    private int despawnDistance = 40;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        PS = GameObject.FindGameObjectWithTag("PointSystem").GetComponent<PointSystem>();
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, yAxis, pos.z);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, camera.transform.position) > despawnDistance)
        {
            Despawn();
        }
    }


    private void Despawn()
    {
        PS.IncreasePointCount();
        Destroy(gameObject);
    }
}
