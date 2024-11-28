using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class door : MonoBehaviour
{
    Animator anim;
    
    private void OnCollisionEnter2D (Collision2D collision)
    {
    anim = GetComponent<Animator>();
        if(collision.gameObject.CompareTag("Player")){
        anim.SetBool("porta", true); 
        anim.SetBool("Aberta", true);   
        
        }
    }
    
}
