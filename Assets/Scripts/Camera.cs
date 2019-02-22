using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public bool scroll;
    public int playerOffset;

    public float cameraMoveSpeed;

    public bool followPlayer;

    private Transform player;
    private GameObject lastSpawnPoint;
    private Spawner spawner;
    private GameObject lastPowerupPosition;
    private PowerupSpawner powerupSpawner;

    private float distanceMovedSinceLastDrop;
    private float distanceMovedSinceLastPowerup;

    public int minSpawnDifference;
    public int maxSpawnDifference;

    private int spawnDifference;

    private int powerupSpawnDifference;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Eater").transform;
        lastSpawnPoint = GameObject.FindGameObjectWithTag("LastSpawnPoint");
        lastPowerupPosition = GameObject.FindGameObjectWithTag("LastPowerupSpawnPoint");
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        powerupSpawner = GameObject.FindGameObjectWithTag("PowerupSpawner").GetComponent<PowerupSpawner>();
        powerupSpawnDifference = maxSpawnDifference;
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll)
        {
            ScrollCamera();
        }

        HandleFollowing();
        HandleDrops();
        HandlePowerups();
    }

    private void HandleFollowing()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(player.position.x + playerOffset, transform.position.y, transform.position.z);
        }
    }

    void ScrollCamera()
    {
        transform.Translate(Vector3.right * cameraMoveSpeed * 0.1f);
    }

    void HandleDrops()
    {
        distanceMovedSinceLastDrop = Vector2.Distance(transform.position, lastSpawnPoint.transform.position);
        if (distanceMovedSinceLastDrop > spawnDifference)
        {
            spawner.SpawnObstacle();
            Vector3 lastPos = lastSpawnPoint.transform.position;
            lastSpawnPoint.transform.position = new Vector3(transform.position.x, lastPos.y, lastPos.z);
            spawnDifference = Random.Range(minSpawnDifference, maxSpawnDifference);
        }
    }

    void HandlePowerups()
    {
        distanceMovedSinceLastPowerup = Vector2.Distance(transform.position, lastPowerupPosition.transform.position);
        if (distanceMovedSinceLastPowerup > powerupSpawnDifference)
        {
            powerupSpawner.RollTheDice();
            Vector3 lastPos = lastPowerupPosition.transform.position;
            lastPowerupPosition.transform.position = new Vector3(transform.position.x, lastPos.y, lastPos.z);
        }
    }
}
