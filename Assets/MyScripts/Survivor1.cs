using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Survivor1 : MonoBehaviour
{
    Animator animator;
    int response = 0;
    int dialog = 0;
    int giveR = 0;
    bool run = false;
    bool stopRun = false;
    float timeRun = 5.0f;
    bool teleport1 = false;
    bool toAttack = false;
    bool underAttack = false;
    bool go1 = false;
    bool go2 = false;
    AudioSource audioSource;
   

    [SerializeField]
    List<GameObject> sound;

    private GameObject sound_inst;

    private NavMeshAgent agent;
    public Transform point;
    public Transform pointReturn;
    public Transform pointAttack;
    Vector3 lastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        //  agent.enabled = true;
        // agent.destination=point.position;

    }

    // Update is called once per frame
    void Update()
    { 
        
        if(response==1&&dialog==0)
        {
            sayLine(sound[dialog]);
        }


        if (dialog == 1 && !audioSource.isPlaying && giveR ==0)
        {

            sendReplyS2(2);
            giveR = 1;
        }



        if (response == 2 && dialog == 1)
        {
            sayLine(sound[dialog]);
        }


        if (dialog == 2 && !audioSource.isPlaying && giveR == 1)
        {

            sendReplyS2(6);
            giveR = 2;
            agent.enabled = true;
            agent.destination=point.position;
           // animator.SetBool("a", true);
           // animator.SetBool("b", false);
            animator.CrossFade("start_run", 0.01f);
            run = true;
          
        }

        if (response == 3 && dialog == 2)
        {
            sayLine(sound[dialog]);
        }


        if (dialog == 3 && !audioSource.isPlaying && giveR == 2)
        {

            sendReplyPlayer(5);
            giveR = 3;
        }


        if(run==true&&toAttack==false)
        {
            timeRun = timeRun - Time.deltaTime;
            if (timeRun <= 0)
            {
                timeRun = 5.0f;
                agent.destination = point.position;
                if (stopRun == true)
                {
                    stopRun = false;
                    animator.CrossFade("start_run", 0.01f);
                }
            }
            else
            {
                if (agent.remainingDistance <= 0.1f&&stopRun==false)
                {
                    timeRun = 5.0f;
                    agent.destination = point.position;
                  
                }
            }

        }
        if (agent.enabled == true)
        {
            if (run == true && agent.remainingDistance < 1.0f && stopRun == false && toAttack == false)
            {
                // animator.SetBool("b", true);
                //animator.SetBool("a", false);
                if (lastPosition == point.position)
                {
                    animator.CrossFade("stop_run", 0.01f);
                    stopRun = true;
                }
            }
        }

        if (toAttack == false)
        {
            lastPosition = point.position;
        }

        if (response == 4 && dialog == 3)
        {
            sayLine(sound[dialog]);
        }


        if (dialog == 4 && !audioSource.isPlaying && giveR == 3)
        {

            sendReplyPlayer(6);
            giveR = 4;
        }

        

        if (dialog == 4 && response == 5 && teleport1 == false)
        {
            transform.position= point.position;
            transform.rotation= point.rotation;
            teleport1 = true;
           // Debug.Log("TeleportS1");
        }
       
        if (dialog == 4 && response == 6)
        {
            sayLine(sound[dialog]);

        }

        if (dialog == 5 && !audioSource.isPlaying && giveR == 4)
        {

            sendReplyPlayer(7);
            giveR = 5;
        }
        if (dialog == 5 && response == 7)
        {
            sayLine(sound[dialog]);

        }

        if (dialog == 6 && !audioSource.isPlaying && giveR == 5)
        {

            sendReplyPlayer(8);
            giveR = 6;
        }

        if (dialog == 6 && response == 8)
        {
            sayLine(sound[dialog]);

        }

        if (dialog == 7 && !audioSource.isPlaying && giveR == 6)
        {

            sendReplyPlayer(9);
            giveR = 7;
        }

        if(dialog==7)
        {
            float distance = Vector3.Distance(transform.position, pointReturn.position);
            if (distance < 40.0f)
            {
                sayLine(sound[dialog]);
            }
        }

        if (dialog == 8 && !audioSource.isPlaying && giveR == 7)
        {

            sendReplyPlayer(10);
            giveR = 8;
        }

        if (dialog == 9 && agent.remainingDistance < 1.5f && go1 == true)
        {
            animator.CrossFade("stop_run", 0.01f);
            Debug.Log("Mes3434");
            go1 = false;
            go2 = true;
        }
        if (dialog == 9 && agent.remainingDistance <= 0.5f && go2 == true)
        {
            Debug.Log("MesS11212");
         //   agent.enabled = false;
            GameObject monster = GameObject.Find("swamp_monster_anm");
            swampMonster monster1 = monster.GetComponent<swampMonster>();
            monster1.GetResponse(1);
            go2 = false;
        }


        if (dialog == 8 && response == 9)
        {
            sayLine(sound[dialog]);
            agent.destination = pointAttack.position;
            agent.speed = 3.5f;
            animator.CrossFade("start_run", 0.01f);
           
            toAttack = true;
           
        }

        if(dialog==9 && agent.remainingDistance>10)
        {
            go1 = true;
        }

            if (dialog==9 &&underAttack==true)
        {
            underAttack = false;
            sayLine(sound[dialog]);
        }

        if (dialog == 10 && !audioSource.isPlaying && giveR == 8)
        {

            sendReplyPlayer(11);
            giveR = 9;
            // Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
        if (agent.destination == pointAttack.position)
       {
            Debug.Log("true");
       }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "monster"&&underAttack==false)

        {
            transform.SetParent(collider.transform);
            agent.isStopped = true;

            underAttack = true;
        }
    }

    public void GetResponse(int x)
    {
        response = x;
    }

    public void Teleport()
    {
        transform.position = point.position;
        transform.rotation = point.rotation;
        Debug.Log("TeleportS1");
    }

    void sayLine(GameObject line)
    {
        sound_inst = Instantiate(line);
        sound_inst.transform.position = transform.position;
        sound_inst.transform.parent = this.transform;
        dialog++;
        audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

    }

    void sendReplyS2(int x)
    {
        GameObject s2 = GameObject.Find("S2");
        Survivor2 survivor2 = s2.GetComponent<Survivor2>();
        survivor2.GetResponse(x);

    }

    void sendReplyPlayer(int x)
    {
        GameObject player = GameObject.Find("Player");
        PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
        player1.GetResponse(x);

    }
}
