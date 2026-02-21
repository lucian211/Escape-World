using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Animator animator;
    float countR = 12;
    bool startCount = false;
    bool stab = false;
    bool act = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount == true)
        {
            countR = countR - Time.deltaTime;
            if  (countR <= 0)
            { startCount = false;
                GameObject player = GameObject.Find("Player");
                PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
                player1.GetResponse(13);
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "stick" && stab == false && act==true)

        {
            animator.SetBool("stab", true);
            startCount = true;
            stab = true;
            GameObject monster = GameObject.Find("swamp_monster_anm");
            swampMonster monster1 = monster.GetComponent<swampMonster>();
            monster1.Stab();
        }
        
    }

    public void CanAct()
    {
        act = true;
    }
}
