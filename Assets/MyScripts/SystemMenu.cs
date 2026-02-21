using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SystemMenu : MonoBehaviour
{
    public Transform place;
    public Transform SysPos1;
    bool Pos1 = false;
    bool dialog6 = false;
    int dialog = 0;
    int response = 0;
    int giveR = 0;
    float timer = 1.0f;
   
    public GameObject portal;
    public ParticleSystem particleSystem;
    AudioSource audioSource;

    [SerializeField]
    List<GameObject> sound;

    private GameObject sound_inst;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = place.position;
    }

    // Update is called once per frame
    void Update()
    {   if (dialog < 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(place.position.x, transform.position.y, place.position.z), Time.deltaTime);
        }
        if (dialog >= 4 && dialog < 7 && Pos1==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, SysPos1.position, Time.deltaTime);
           if(transform.position==SysPos1.position)
            { Pos1 = true; }
            
        }

        if (dialog >= 7&& dialog < 14)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(place.position.x, transform.position.y, place.position.z), Time.deltaTime);
        }

        if (dialog >= 14 && Pos1 == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, SysPos1.position, Time.deltaTime);
            if (transform.position == SysPos1.position)
            { Pos1 = true; }

        }

        if (dialog == 0)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                sayLine(sound[dialog]);

            }
        }

        if (dialog == 1 && !audioSource.isPlaying && giveR == 0)
        {

            sendReplyPlayer(1);
            giveR = 1;
        }

        if (dialog == 1 && response == 1)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 2 && !audioSource.isPlaying && giveR == 1)
        {

            sendReplyPlayer(2);
            giveR = 2;

        }

        if (dialog == 2 && response == 2)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 3 && !audioSource.isPlaying && giveR == 2)
        {

            sendReplyPlayer(3);
            giveR = 3;

        }

        if (dialog == 3 && response == 3)
        {
            sayLine(sound[dialog]);
            GameObject usaS =GameObject.Find("usa");
            usa Usa = usaS.GetComponent<usa>();
            Usa.openDoor();
          
        }

        if (dialog == 4 && !audioSource.isPlaying && giveR == 3)
        {

            sendReplyPlayer(4);
            giveR = 4;
        }

        if (dialog == 4 && response == 4)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 5 && !audioSource.isPlaying && giveR == 4)
        {

            sendReplyPlayer(5);
            giveR = 5;
        }

        if (dialog == 5 && response == 5)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 6 && !audioSource.isPlaying && giveR == 5)
        {

            sendReplyPlayer(6);
            giveR = 6;

        }

        if (dialog == 6 && response == 6)
        {
            sayLine(sound[dialog]);
            dialog6 = true;
            particleSystem.Stop();
            
        }

        if (dialog == 7 && dialog6==true)
        {
            if (!audioSource.isPlaying && giveR==6)
            {
              
                giveR = 7;
                portal.SetActive(true);
           }
        }

        ////Level 2

        if (dialog == 7 && dialog6==false)
        {
            sayLine(sound[dialog]);
        }

        ///Level 1 Repeat

        if (dialog == 8 && response == 7)
        {
            sayLine(sound[dialog]);
          
            
        }

        if (dialog == 9 && !audioSource.isPlaying && giveR == 0)
        {

            sendReplyPlayer(7);
            giveR = 1;
        }

        if (dialog == 9 && response == 8)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 10 && !audioSource.isPlaying && giveR == 1)
        {

            sendReplyPlayer(8);
            giveR = 2;
        }

        if (dialog == 10 && response == 9)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 11 && !audioSource.isPlaying && giveR == 2)
        {

            sendReplyPlayer(9);
            giveR = 3;
        }

        if (dialog == 11 && response == 10)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 12 && !audioSource.isPlaying && giveR == 3)
        {

            sendReplyPlayer(10);
            giveR = 4;
        }

        if (dialog == 12 && response == 11)
        {
            sayLine(sound[dialog]);
        }

        if (dialog == 13 && !audioSource.isPlaying && giveR == 4)
        {

            sendReplyPlayer(11);
            giveR = 5;
        }

        if (dialog == 13 && response == 12)
        {
            sayLine(sound[dialog]);
          
            GameObject usaS = GameObject.Find("usa");
            usa Usa = usaS.GetComponent<usa>();
            Usa.openDoor();
           
        }

        if (dialog == 14)
        {
            if (!audioSource.isPlaying)
            {
                portal.SetActive(true);
                particleSystem.Stop();
            }
        }

    }

    public void GetResponse(int x)
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

    void sendReplyPlayer(int x)
    {
        GameObject player = GameObject.Find("Player");
        PlayerMenu playerMenu = player.GetComponent<PlayerMenu>();
        playerMenu.GetResponse(x);
    }
}
