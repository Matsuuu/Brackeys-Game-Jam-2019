using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            LoadMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadMenu();
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
