using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swampMonster : MonoBehaviour
{
    public List<GameObject> DestinationPoints;
    public List<GameObject> DestinationPoints2;
    public List<GameObject> target;


    Animator animator;
    bool attack = false;
    bool canAttack = false;
    float timeUntilAttack = 5.0f;
    bool moveUp = false;
    bool moveDown =false;
    bool isAttacking = false;
    bool startAnim = true;
    float timeAttack = 11.0f;
    float distance = 100.0f;
    int rand;
    int index = 0;
    int targetCount = 0;
    int response = 0;
    Vector3 targetSound = new Vector3(0,0,0);
    bool newtargetSound = false;
    bool canGetSound = false;
    int notifyPlayer = 0;
    private static System.Random rnd = new System.Random();

    [SerializeField]
    GameObject scream;
    AudioSource audioSource;

    private GameObject sound_inst;

    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(response==1)
        {
            canAttack = true;
            response = 0;
        }



        if(canAttack==true && alive==true)
        {
            timeUntilAttack = timeUntilAttack-Time.deltaTime;
            if (timeUntilAttack<=0)
            {
                timeUntilAttack = 20.0f;
                canAttack = false;
                attack = true;
                canGetSound = false;
            }
        }
        
        if (attack==true)
        {
           // rand = rnd.Next(0, target.Count);
            float minDistance = 10000.0f;
            index = 0;
            for (int i = 0; i < DestinationPoints.Count; i++)
            {   if (newtargetSound == false)
                {
                    distance = Vector3.Distance(target[targetCount].transform.position, DestinationPoints[i].transform.position);
                }
            else
                {
                    distance = Vector3.Distance(targetSound, DestinationPoints[i].transform.position);
                }

                if (distance < minDistance && distance < 50)
                {
                    index = i;
                    minDistance = distance;
                }
            }
            if(minDistance<50)
             {
                attack = false;
                minDistance = 10000.0f;
                moveUp = true;
                transform.position = DestinationPoints[index].transform.position;
                if (newtargetSound == false)

                { transform.LookAt(new Vector3(target[targetCount].transform.position.x, transform.position.y, target[targetCount].transform.position.z), Vector3.up); }
                
                else
                { transform.LookAt(new Vector3(targetSound.x, transform.position.y, targetSound.z), Vector3.up); }
            

                if (newtargetSound == true)
                {
                    newtargetSound = false;
                    if (notifyPlayer == 0)
                    { notifyPlayer = 1; }
                }
             }
             if(minDistance>=50)
            {
                if(newtargetSound==true)
                {
                    newtargetSound = false;
                }
            }
            
        }

        if(moveUp==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, DestinationPoints2[index].transform.position,3* Time.deltaTime);
            if(transform.position.y>= DestinationPoints2[index].transform.position.y)
            {
                sound_inst = Instantiate(scream);
                sound_inst.transform.position = transform.position;
                audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

                moveUp = false;
                isAttacking = true;
                animator.SetBool("attack", true);
                //animator.CrossFade("attack", 0.01f);
                startAnim = true;
                if(notifyPlayer==1)
                {
                    notifyPlayer = 2;
                    GameObject player = GameObject.Find("Player");
                    PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
                    player1.GetResponse(12);
                }
            }
        }
        if(isAttacking==true)
        {
            timeAttack = timeAttack - Time.deltaTime;
            if (timeAttack < 4 && startAnim==true)
            {
                animator.SetBool("attack", false);
                startAnim = false;
            }

            if (timeAttack<=0)
            {  
            
                timeAttack = 11.0f;
                isAttacking = false;
                moveDown = true;
               // animator.SetBool("attack", false);
            }
        }

        if(moveDown==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, DestinationPoints[index].transform.position,2* Time.deltaTime);
            if (transform.position.y <= DestinationPoints[index].transform.position.y)
            {
                Destroy(sound_inst);
                moveDown = false;
                canAttack = true;
                canGetSound = true;
            }
            if (targetCount == 0)
                targetCount = 1;
           
        }
    }

    public void GetResponse(int x)
    {
        response = x;
    }

    public void Stab()
    {
        alive = false;
    }

    public void GetTarget(Vector3 target)
    {   if (canGetSound == true &&canAttack==true)
        {
            targetSound = target;
            newtargetSound = true;
            Debug.Log("Monster target");
        }
    }
}
