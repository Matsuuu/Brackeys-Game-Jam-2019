using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public bool scroll;

    public float cameraMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll)
        {
            ScrollCamera();
        }
    }

    void ScrollCamera()
    {
        transform.Translate(Vector3.right * cameraMoveSpeed * 0.1f);
    }
}
