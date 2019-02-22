using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerUp;
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

    public void RollTheDice()
    {
        int rng = Random.Range(0, 2);
        Debug.Log("THE DICE ROLL RESULTED IN " + rng);
        if (rng == 0)
        {
            SpawnPowerup();
        }
    }

    private void SpawnPowerup()
    {
        Vector3 thisPos = transform.position;
        Instantiate(powerUp, new Vector3(thisPos.x, 0 + Random.Range(-4, 4), thisPos.z), transform.rotation);
    }
}
