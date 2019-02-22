using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwapper : MonoBehaviour
{
    public int backgroundWidth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Katosi");
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + backgroundWidth * 2, pos.y, pos.z);
    }
}
