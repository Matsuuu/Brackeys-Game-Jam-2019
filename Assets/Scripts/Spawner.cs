using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform obstacleHolder;
    public Vector3 offset;

    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        obstacleHolder = GameObject.FindGameObjectWithTag("ObstacleHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnObstacle();
        }
        Vector3 pos = transform.position;
        transform.position = new Vector3(camera.position.x + offset.x, pos.y, pos.z);
    }

    public void SpawnObstacle()
    {
        int obstaclenum = Random.Range(0, obstacles.Length);
        GameObject obstacleToSpawn = obstacles[obstaclenum];
        GameObject obs = Instantiate(obstacleToSpawn, transform.position, transform.rotation);
        obs.transform.parent = obstacleHolder;
    }
}
