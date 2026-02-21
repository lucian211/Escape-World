using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStory1 : MonoBehaviour
{
    int dialog = 0;
    int response = 0;
    int giveR = 0;
    float timer = 4.0f;
    bool height = false;
    public CharacterController CC;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public GameObject fog;
    public GameObject end;
    public GameObject mud1;
    public GameObject mud2;
    public GameObject mud3;
    bool teleport = false;
    bool closeFog = false;
    float timeFog = 7.0f;
    bool S2disapear = false;
    bool S1teleport = false;
    float timeTeleport = 2.5f;
    float timeR9 = 5.0f;
    bool countR9 = false;
    bool countD15 = false;
    float timeD15 = 55.0f;
    bool countD18 = false;
    float timeD18 = 20.0f;
    bool countD19 = false;
    float timeD19 = 15.0f;
    bool countD21 = false;
    float timeD21 = 7.0f;
    int placeTeleport = 0;
    public Transform meteor;

    [SerializeField]
    List<GameObject> sound;

    private GameObject sound_inst;

    AudioSource audioSource;

    [SerializeField]
    GameObject scream;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        CC = GetComponent<CharacterController>();
        CC.height = 2.5f;
    }


    // Update is called once per frame
    void Update()
    {


        if (transform.position.x < 50)
        {
            fog.SetActive(true);
            placeTeleport = 1;
            teleport = true;


        }

        if (transform.position.z < 310)
        {
            fog.SetActive(true);
            placeTeleport = 2;
            teleport = true;


        }

        if (transform.position.x > 390)
        {
            fog.SetActive(true);
            placeTeleport = 3;
            teleport = true;


        }
        if (teleport == true)
        {
            timeTeleport = timeTeleport - Time.deltaTime;
            if (timeTeleport <= 0)
            {
                timeTeleport = 2.5f;
                teleport = false;
                if (placeTeleport == 1)
                {
                    transform.position = spawn1.position;
                    transform.rotation = spawn1.rotation;

                }
                if (placeTeleport == 2)
                {
                    transform.position = spawn2.position;
                    transform.rotation = spawn2.rotation;

                }
                if (placeTeleport == 3)
                {
                    transform.position = spawn3.position;
                    transform.rotation = spawn3.rotation;

                }
                closeFog = true;

                if (S1teleport == true)
                {
                    GameObject s1 = GameObject.Find("S1");
                    Survivor1 survivor1 = s1.GetComponent<Survivor1>();
                    survivor1.Teleport();
                  
                }

                if (S1teleport == false)
                {
                    sendReplyS1(5);
                    S1teleport = true;
                    
                }


                if (S2disapear == false)
                {
                    GameObject s2 = GameObject.Find("S2");
                    Survivor2 survivor2 = s2.GetComponent<Survivor2>();
                    survivor2.Dissapear();
                    S2disapear = true;
                }
            }

        }

        if (closeFog == true)
        {
            timeFog = timeFog - Time.deltaTime;
            if (timeFog <= 0)
            {
                timeFog = 7.0f;
                closeFog = false;
                fog.SetActive(false);
            }
        }


        if (height == false)
        {
            height = true;
            CC.height = 2.5f;
        }


        if (dialog == 0)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                sayLine(sound[dialog]);
                timer = 4.0f;

            }
        }
        if (dialog == 1 && !audioSource.isPlaying)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                sayLine(sound[dialog]);
                timer = 2.0f;

            }
        }

        if (dialog == 2 && !audioSource.isPlaying && giveR == 0)
        {

            sendReplyS2(1);
            giveR = 1;
        }

        if (dialog == 2 && response == 1)
        {
            sayLine(sound[dialog]);

        }

        if (dialog == 3 && !audioSource.isPlaying && giveR == 1)
        {

            sendReplyS2(3);
            giveR = 2;
        }

        if (dialog == 3 && response == 2)
        {
            sayLine(sound[dialog]);

        }



        if (dialog == 4 && !audioSource.isPlaying)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                sayLine(sound[dialog]);
                timer = 2;
            }
        }

        if (dialog == 5 && !audioSource.isPlaying && giveR == 2)
        {

            sendReplyS2(4);
            giveR = 3;
        }




        if (dialog == 5 && response == 3)
        {

            sayLine(sound[dialog]);

        }



        if (dialog == 6 && !audioSource.isPlaying && giveR == 3)
        {

            sendReplyS2(5);
            giveR = 4;
        }

        if (dialog == 6 && response == 4)
        {

            sayLine(sound[dialog]);

        }
        if (dialog == 7 && !audioSource.isPlaying && giveR == 4)
        {

            sendReplyS1(3);
            giveR = 5;
        }

        if (dialog == 7 && response == 5)
        {

            sayLine(sound[dialog]);

        }
        if (dialog == 8 && !audioSource.isPlaying && giveR == 5)
        {

            sendReplyS1(4);
            giveR = 6;
        }

        if (dialog == 8 && response == 6)
        {

            sayLine(sound[dialog]);

        }

        if (dialog == 9 && closeFog == true)
        {
            sayLine(sound[dialog]);
        }
        if (dialog == 10 && !audioSource.isPlaying && giveR == 6)
        {
            sendReplyS1(6);
            giveR = 7;
        }



        if (dialog == 10 && response == 7)
        {

            sayLine(sound[dialog]);

        }

        if (dialog == 11 && !audioSource.isPlaying && giveR == 7)
        {
            sendReplyS1(7);
            giveR = 8;
        }

        if (dialog == 11 && response == 8)
        {

            sayLine(sound[dialog]);

        }

        if (dialog == 12 && !audioSource.isPlaying && giveR == 8)
        {
            sendReplyS1(8);
            giveR = 9;
        }

        if (dialog == 12 && response == 9)
        {
            countR9 = true;


        }

        if (countR9 == true)
        {
            timeR9 = timeR9 - Time.deltaTime;
            if (timeR9 <= 0)
            {

                countR9 = false;
                sayLine(sound[dialog]);
            }
        }

        if (dialog == 13 && response == 10)
        {

            sayLine(sound[dialog]);

        }
        if (dialog == 14 && !audioSource.isPlaying && giveR == 9)
        {
            sendReplyS1(9);
            giveR = 10;
        }

        if (dialog == 14 && response == 11)
        {

            sayLine(sound[dialog]);
            countD15 = true;

        }

        if (countD15 == true)
        {
            timeD15 = timeD15 - Time.deltaTime;
            if (timeD15 <= 0)
            {

                countD15 = false;
                sayLine(sound[dialog]);
            }
        }

        if (dialog == 16 && response == 12)
        {
            sayLine(sound[dialog]);
        }

        if(dialog==17&&countD18==false)
        {
           float distance = Vector3.Distance(transform.position, meteor.position);
            if (distance<20)
            {
                sound_inst = Instantiate(sound[dialog]);
                sound_inst.transform.position = transform.position;
                sound_inst.transform.parent = this.transform;
                countD18 = true;
                audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

            }
        }

        if (countD18 == true)
        {
            timeD18 = timeD18 - Time.deltaTime;
            if (timeD18 <= 0)
            {

                countD18 = false;
                dialog = 18;
            }
        }

        if (dialog == 18)
        {
            float distance = Vector3.Distance(transform.position, meteor.position);
            if (distance < 5)
            {
                sayLine(sound[dialog]);
                GameObject m= GameObject.Find("aliveMeteor");
                Meteor meteor = m.GetComponent<Meteor>();
                meteor.CanAct();
              
            }
        }

        if (dialog == 19 && response == 13)
        {
            sayLine(sound[dialog]);
            end.SetActive(true);
            countD19 = true;

        }

        if(countD19==true)
        {
            timeD19 = timeD19 - Time.deltaTime;
            if (timeD19 <= 0)
            {

                countD19 = false;
                GameObject m = GameObject.Find("Manager");
                Scene1Manager scene1manager = m.GetComponent<Scene1Manager>();
                scene1manager.Win();
            }
        }
        if (countD21 == true)
        {
            timeD21 = timeD21 - Time.deltaTime;
            if (timeD21 <= 0)
            {

                countD21 = false;
                GameObject m = GameObject.Find("Manager");
                Scene1Manager scene1manager = m.GetComponent<Scene1Manager>();
                scene1manager.Lose();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "swamp"&& dialog!=21)

        {
            Destroy(sound_inst);
            dialog = 21;
            sound_inst = Instantiate(scream);
            sound_inst.transform.position = transform.position;
            sound_inst.transform.parent = this.transform;
            audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
            mud1.SetActive(true);
            mud2.SetActive(true);
            mud3.SetActive(true);
            countD21 = true;
            end.SetActive(true);
        }

        if (collider.gameObject.tag == "monster" && dialog != 21)

        {
            Destroy(sound_inst);
            dialog = 21;
            sound_inst = Instantiate(scream);
            countD21 = true;
            audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
            mud1.SetActive(true);
            mud2.SetActive(true);
            mud3.SetActive(true);
            end.SetActive(true);
        }

    }
    public void GetResponse(int x)
    {
        response = x;
    }

    void sayLine(GameObject line)
    {
        sound_inst = Instantiate(line);
        sound_inst.transform.position = transform.position;
        sound_inst.transform.parent = this.transform;
        dialog++;
        audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

    }

    void sendReplyS1(int x)
    {
        GameObject s1 = GameObject.Find("S1");
        Survivor1 survivor1 = s1.GetComponent<Survivor1>();
        survivor1.GetResponse(x);

    }

    void sendReplyS2(int x)
    {
        GameObject s2 = GameObject.Find("S2");
        Survivor2 survivor2 = s2.GetComponent<Survivor2>();
        survivor2.GetResponse(x);

    }
}
