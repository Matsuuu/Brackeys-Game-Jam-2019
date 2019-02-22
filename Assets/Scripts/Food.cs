using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    public float emissionRate;
    public float hitCooldown;
    public int healthDecreaseAmount;
    
    public GameObject waypoint;
    public GameObject lastWaypoint;

    private HealthBar healthBar;
    private bool canBeHurt;

    // Start is called before the first frame update

    void Start()
    {
        canBeHurt = true;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        GameObject startingWaypoint = Instantiate(waypoint, transform.position, transform.rotation);
        GameObject.FindGameObjectWithTag("Eater").GetComponent<Eater>().setTarget(startingWaypoint);
        lastWaypoint = startingWaypoint;
        StartCoroutine(CreateWaypoints());
    }

    IEnumerator CreateWaypoints()
    {
        GameObject newWayPoint = Instantiate(waypoint, transform.position, transform.rotation);
        lastWaypoint.GetComponent<Waypoint>().SetNewWaypoint(newWayPoint);
        lastWaypoint = newWayPoint;
        yield return new WaitForSeconds(emissionRate);
        yield return StartCoroutine(CreateWaypoints());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Eater") && canBeHurt)
        {
            canBeHurt = false;
            StartCoroutine(DecreaseHealth());
        }
    }

    private IEnumerator DecreaseHealth()
    {
        healthBar.decreaseHealth(healthDecreaseAmount);
        yield return new WaitForSeconds(hitCooldown);
        canBeHurt = true;
        if (healthBar.health <= 0)
        {
            HealthEndGame();
        }
    }

    private void HealthEndGame()
    {
        SceneManager.LoadScene("PieLoseScene");
    }

}
