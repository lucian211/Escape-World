using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    int level = 1;
    int repeat= 0;
    public GameObject System;
    bool canEnterWorld = false;
    int world = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("Level", 0) == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            
        }
       level = PlayerPrefs.GetInt("Level", 0);

        if (PlayerPrefs.GetInt("Repeat", 0) != 0)
        {
            PlayerPrefs.SetInt("Repeat", 0);
            repeat = 1;

        }
        if (level == 1 && repeat == 1)
        {
            System.gameObject.SetActive(true);

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetLevel(8);

            GameObject player = GameObject.Find("Player");
            PlayerMenu playerMenu = player.GetComponent<PlayerMenu>();
            playerMenu.GetLevel(7);


        }

        if (level == 2)
        {
            System.gameObject.SetActive(true);

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetLevel(7);

            GameObject player = GameObject.Find("Player");
            PlayerMenu playerMenu = player.GetComponent<PlayerMenu>();
            playerMenu.GetLevel(100);

        } 

    }

    // Update is called once per frame
    void Update()
    {
        if(canEnterWorld==true)

        {
            canEnterWorld = false;
            SceneManager.LoadScene(world);
        }
    }

    public void EnterWorld( int x)
    {
        if(canEnterWorld==false)
        {
            canEnterWorld = true;
            world = x;
        }
    }
}
