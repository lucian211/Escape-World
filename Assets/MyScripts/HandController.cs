using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController Controller = null;

   
    private Animator animator;
    private bool isOpen = true;


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
       
     }


    private void Update()
    {
        if(Controller.selectAction.action.ReadValue<float>()!=0&&isOpen==true)
        {
            animator.CrossFade("grab", 0.01f);
            isOpen = false;
        }
        if (Controller.selectAction.action.ReadValue<float>() == 0 && isOpen == false)
        {
            animator.CrossFade("grab_final", 0.01f);
            isOpen = true;
        }

  


        }

}



