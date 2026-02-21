using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Wood : MonoBehaviour
{

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    bool selected = false;

    [SerializeField]
    GameObject sound;

    private GameObject sound_inst;

    AudioSource audioSource;
    int countSound = 0;

    // Start is called before the first frame update
    private void Start()
    {
      

        grabInteractable = GetComponent<XRGrabInteractable>();

        rb = GetComponent<Rigidbody>();

        grabInteractable.onSelectEntered.AddListener(OnSelectEnter);
        grabInteractable.onSelectExited.AddListener(OnSelectExit);
    }

    private void OnSelectEnter(XRBaseInteractor interactor)
    {
        selected = true;
        rb.useGravity = true;
       // Debug.Log("Selected");
    }

    private void OnSelectExit(XRBaseInteractor interactor)
    {
        rb.AddForce(transform.forward* 7.0f, ForceMode.Impulse);
        rb.AddForce(transform.up* 3.0f, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "teren" && selected == true)
        {
            selected = false;
            GameObject monster = GameObject.Find("swamp_monster_anm");
            swampMonster monster1 = monster.GetComponent<swampMonster>();
            monster1.GetTarget(transform.position);
            if (countSound < 3)
            {
                sound_inst = Instantiate(sound);
                sound_inst.transform.position = transform.position;
                audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
                countSound = countSound + 1;
                Debug.Log("SoundBum");
            }
        }
        if (collision.gameObject.tag != "teren" && selected==false)
        { rb.useGravity = true;
            
        }

        if (collision.gameObject.tag != "teren" && selected == true)
        {
            sound_inst = Instantiate(sound);
            sound_inst.transform.position = transform.position;
            audioSource = sound_inst.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
            countSound = countSound + 1;
            Debug.Log("SoundBum2");
        }

    }

    }
