using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public float moveSpeed;

    public float highestPoint;

    public float lowestPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 position = transform.position;
        if (verticalAxis > 0 && position.y >= highestPoint)
        {
            verticalAxis = 0;
        }

        if (verticalAxis < 0 && position.y <= lowestPoint)
        {
            verticalAxis = 0;
        }
        
        transform.Translate(new Vector3(horizontalAxis, verticalAxis, 0) * moveSpeed * Time.deltaTime);
    }
}
