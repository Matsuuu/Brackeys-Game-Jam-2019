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
    private GameObject lastCollectiblePoint;
    private CollectibleSpawner collectibleSpawner;

    private float distanceMovedSinceLastDrop;
    private float distanceMovedSinceLastPowerup;
    private float distanceMovedSinceLastCollectible;

    public int minSpawnDifference;
    public int maxSpawnDifference;

    private int spawnDifference;

    private int powerupSpawnDifference;

    private int collectibleSpawnDifference;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Eater").transform;
        lastSpawnPoint = GameObject.FindGameObjectWithTag("LastSpawnPoint");
        lastPowerupPosition = GameObject.FindGameObjectWithTag("LastPowerupSpawnPoint");
        lastCollectiblePoint = GameObject.FindGameObjectWithTag("LastCollectibleSpawnPoint");
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        powerupSpawner = GameObject.FindGameObjectWithTag("PowerupSpawner").GetComponent<PowerupSpawner>();
        collectibleSpawner = GameObject.FindGameObjectWithTag("CollectibleSpawner").GetComponent<CollectibleSpawner>();
        powerupSpawnDifference = maxSpawnDifference;
        collectibleSpawnDifference = maxSpawnDifference;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (scroll)
        {
            ScrollCamera();
        }

        HandleFollowing();
        HandleDrops();
        HandlePowerups();
        HandleCollectibles();
    }

    private void HandleFollowing()
    {
        if (followPlayer)
        {
            //transform.position = new Vector3(player.position.x + playerOffset, transform.position.y, transform.position.z);
            Vector3 targetPos = new Vector3(player.transform.position.x + playerOffset, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, cameraMoveSpeed);
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

    private void HandleCollectibles()
    {
        distanceMovedSinceLastCollectible = Vector2.Distance(transform.position, lastCollectiblePoint.transform.position);
        if (distanceMovedSinceLastCollectible > collectibleSpawnDifference)
        {
            collectibleSpawner.SpawnCollectible();
            Vector3 lastPos = lastCollectiblePoint.transform.position;
            lastCollectiblePoint.transform.position = new Vector3(transform.position.x, lastPos.y, lastPos.z);
        }
    }
}
