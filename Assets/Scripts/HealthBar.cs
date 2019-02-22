using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public Sprite[] healthSprites;
    public Sprite currentSprite;
    public Image healthImage;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        SetIconAccordingToHealth();
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void decreaseHealth(float amount)
    {
        this.health = this.health - amount;
    }

    public void increaseAmount(float amount)
    {
        this.health = this.health + amount;
    }

    public void SetIconAccordingToHealth()
    {
        if (health >= 80)
        {
            currentSprite = healthSprites[0];
        }

        if (health < 80 && health >= 60)
        {
            currentSprite = healthSprites[1];
        }

        if (health < 60 && health >= 40)
        {
            currentSprite = healthSprites[2];
        }

        if (health < 40 && health >= 20)
        {
            currentSprite = healthSprites[3];
        }

        if (health < 20)
        {
            currentSprite = healthSprites[4];
        }

        healthImage.sprite = currentSprite;
    }

}
