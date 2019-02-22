using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectible;
    private Transform camera;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(camera.position.x + offset.x, pos.y, pos.z);
    }
    
    public void SpawnCollectible()
    {
        Vector3 thisPos = transform.position;
        Instantiate(collectible, new Vector3(thisPos.x, 0 + Random.Range(-6, 6), thisPos.z), transform.rotation);
    }
}
