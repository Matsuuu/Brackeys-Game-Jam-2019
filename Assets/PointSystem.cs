using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    private int currentPoints;

    private Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
        pointText = GameObject.FindGameObjectWithTag("PointText").GetComponent<Text>();
        pointText.text = "Points: " + currentPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreasePointCount()
    {
        currentPoints++;
        pointText.text = "Points: " + currentPoints;
    }
}
