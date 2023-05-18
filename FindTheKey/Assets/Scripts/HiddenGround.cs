using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenGround : MonoBehaviour
{


    private Animator myAnimator;



    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        
        if (other.gameObject.CompareTag("Player"))
        {
            //Play the Anim

            PlayShowAnim();
        }
    }


    void PlayShowAnim()
    {
        myAnimator.SetTrigger("Show");
    }
}
