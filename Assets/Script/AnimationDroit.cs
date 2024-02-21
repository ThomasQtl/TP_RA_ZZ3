using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDroit : MonoBehaviour
{
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void PlayAnimation()
    {

            animator.SetBool("lance", true);
            Debug.Log("lancer");
   
 
    }

    public void DeplayAnimation()
    {
        animator.SetBool("lance", false);
        Debug.Log("arret");

    }
}
