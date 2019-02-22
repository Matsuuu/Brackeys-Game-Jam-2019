using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public float moveSpeed;
    private float startMovespeed;

    public float highestPoint;

    public float lowestPoint;

    public int powerupDuration;
    // Start is called before the first frame update
    void Start()
    {
        startMovespeed = moveSpeed;
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
    
    public void Boost()
    {
        StartCoroutine(DoBoost());
    }

    private IEnumerator DoBoost()
    {
        moveSpeed = startMovespeed * 1.2f;
        yield return new WaitForSeconds(powerupDuration);
        moveSpeed = startMovespeed;
    }
}
