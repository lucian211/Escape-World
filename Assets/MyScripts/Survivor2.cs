using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor2 : MonoBehaviour
{

    float distance = 1000.0f;
    public Transform playerPosition;
    int response = 0;
    int dialog = 0;
    int giveR=0;
    AudioSource audioSource;


    [SerializeField]
    List<GameObject> sound;

    private GameObject sound_inst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (response == 1 && dialog == 0)
        {
            distance = Vector3.Distance(transform.position, playerPosition.position);
            if (distance < 5.0f)
            {
                sayLine(sound[dialog]);
            }
        }
        


        if (dialog == 1 && !audioSource.isPlaying&& giveR==0)
        {

            GameObject s1 = GameObject.Find("S1");
            Survivor1 survivor1 = s1.GetComponent<Survivor1>();
            survivor1.GetResponse(1);
            giveR = 1;
        }

        if (response == 2 && dialog == 1)
        {
            sayLine(sound[dialog]);


        }

        if (dialog == 2 && !audioSource.isPlaying && giveR == 1)
        {

            GameObject player = GameObject.Find("Player");
            PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
            player1.GetResponse(1);
            giveR = 2;
        }


        if (response == 3 && dialog == 2)
        {
            sayLine(sound[dialog]);


        }


        if (dialog == 3 && !audioSource.isPlaying && giveR == 2)
        {

            GameObject player = GameObject.Find("Player");
            PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
            player1.GetResponse(2);
            giveR = 3;
        }

        if (response == 4 && dialog == 3)
        {
            sayLine(sound[dialog]);


        }


        if (dialog == 4 && !audioSource.isPlaying && giveR == 3)
        {

            GameObject player = GameObject.Find("Player");
            PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
            player1.GetResponse(3);
            giveR = 4;
        }

        if (response == 5 && dialog == 4)
        {
            sound_inst = Instantiate(sound[dialog]);
            sound_inst.transform.position = transform.position;
            sound_inst.transform.parent = this.transform;
            dialog = 5;
            audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();


        }


        if (dialog == 5 && !audioSource.isPlaying && giveR == 4)
        {
            GameObject s1 = GameObject.Find("S1");
            Survivor1 survivor1 = s1.GetComponent<Survivor1>();
            survivor1.GetResponse(2);
            giveR = 5;
        }

        if (response == 6 && dialog == 5)
        {
            sayLine(sound[dialog]);


        }


        if (dialog == 6 && !audioSource.isPlaying && giveR == 5)
        {
            GameObject player = GameObject.Find("Player");
            PlayerStory1 player1 = player.GetComponent<PlayerStory1>();
            player1.GetResponse(4);

            giveR = 6;
        }
    }

    public void GetResponse(int x)
    {
        response = x;
    }
    public void Dissapear()
    {
        Destroy(this.gameObject);
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
