using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usa : MonoBehaviour
{
    Animator animator;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
       animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {   if (start == true)
        {
            animator.SetBool("open", true);
            start = false;
        }
    }

    public void openDoor()
    { start = true; }
}
