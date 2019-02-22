using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float yAxis;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, yAxis, pos.z);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
