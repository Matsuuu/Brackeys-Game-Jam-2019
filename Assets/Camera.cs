using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public bool scroll;

    public float cameraMoveSpeed;

    public bool followPlayer;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Eater").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll)
        {
            ScrollCamera();
        }

        HandleFollowing();
    }

    private void HandleFollowing()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

    void ScrollCamera()
    {
        transform.Translate(Vector3.right * cameraMoveSpeed * 0.1f);
    }
}
