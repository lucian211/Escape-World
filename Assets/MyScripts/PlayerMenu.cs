using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMenu : MonoBehaviour
{
    public CharacterController CC;
    bool height = false;
    int dialog = 0;
    int response = 0;
    int giveR = 0;
    float timer = 2.0f;
    public GameObject System;
    AudioSource audioSource;
    bool touchBarrier = false;
    bool touchPortal = false;

    [SerializeField]
    List<GameObject> sound;

    private GameObject sound_inst;

    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CharacterController>();
        CC.height = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (height == false)
        {
            height = true;
            CC.height = 2;
        }

        if (dialog == 0)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                sayLine(sound[dialog]);
              
                timer = 2.0f;
            }
        }
        if (dialog == 1 && !audioSource.isPlaying && giveR==0)
        {

            System.gameObject.SetActive(true);
            giveR = 1;
        }

        if (dialog == 1 && response == 1)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 2 && !audioSource.isPlaying && giveR==1)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(1);
            giveR = 2;
        }

        if (dialog == 2 && response == 2)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 3 && !audioSource.isPlaying && giveR == 2)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(2);
            giveR = 3;
        }

        if (dialog == 3 && response == 3)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 4 && !audioSource.isPlaying && giveR == 3)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(3);
            giveR = 4;
        }

        if (dialog == 4 && response == 4 && touchBarrier == true)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 5 && !audioSource.isPlaying && giveR == 4)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(4);
            giveR = 5;
        }

        if (dialog == 5 && response == 5)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 6 && !audioSource.isPlaying && giveR == 5)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(5);
            giveR = 6;
        }

        if (dialog == 6 && response == 6)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 7 && giveR == 6)
        {
            if (!audioSource.isPlaying)
            {
                GameObject system = GameObject.Find("System");
                SystemMenu systemMenu = system.GetComponent<SystemMenu>();
                systemMenu.GetResponse(6);
                giveR = 7;
            }
        }

        if (dialog == 7 && touchPortal == true)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                GameObject m = GameObject.Find("MenuManager");
                MenuManager menumanager = m.GetComponent<MenuManager>();
                menumanager.EnterWorld(1);
            }
        }

        /// Level 1 Repeat

        if (dialog == 7 && giveR == 0)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 8 && !audioSource.isPlaying && giveR == 0)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(7);
            giveR = 1;
        }

        if (dialog == 8 && response == 7)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 9 && !audioSource.isPlaying && giveR == 1)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(8);
            giveR = 2;
        }

        if (dialog == 9 && response == 8)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 10 && !audioSource.isPlaying && giveR == 2)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(9);
            giveR = 3;
        }

        if (dialog == 10 && response == 9)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 11 && !audioSource.isPlaying && giveR == 3)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(10);
            giveR = 4;
        }

        if (dialog == 11 && response == 10)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 12 && !audioSource.isPlaying && giveR == 4)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(11);
            giveR = 5;
        }

        if (dialog == 12 && response == 11)
        {

            sayLine(sound[dialog]);
        }

        if (dialog == 13 && !audioSource.isPlaying && giveR == 5)
        {

            GameObject system = GameObject.Find("System");
            SystemMenu systemMenu = system.GetComponent<SystemMenu>();
            systemMenu.GetResponse(12);
            giveR = 6;
        }


        if (dialog == 13 && touchPortal == true)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                GameObject m = GameObject.Find("MenuManager");
                MenuManager menumanager = m.GetComponent<MenuManager>();
                menumanager.EnterWorld(1);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit collision)
    {
       
        if (collision.gameObject.tag == "portal" && dialog == 7&& touchPortal==false)
        {
            GameObject eyes = GameObject.Find("PanelE");
            Eyes eyesScr = eyes.GetComponent<Eyes>();
            eyesScr.closeEyes();
            touchPortal = true;
        }

        if (collision.gameObject.tag == "portal" && dialog == 13 && touchPortal == false)
        {
            GameObject eyes = GameObject.Find("PanelE");
            Eyes eyesScr = eyes.GetComponent<Eyes>();
            eyesScr.closeEyes();
            touchPortal = true;
            
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "barrier" && touchBarrier == false && dialog == 4)

        {
            touchBarrier = true;
        }
    }

    public void GetResponse(int x)
    {
        response = x;
    }

    public void WhenIAm(int x)
    {
        response = x;
    }
    public void GetLevel(int x)
    {
        dialog = x;
    }

    void sayLine(GameObject line)
    {
        sound_inst = Instantiate(line);
        sound_inst.transform.position = transform.position;
        sound_inst.transform.parent = this.transform;
        dialog++;
        audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

    }
}