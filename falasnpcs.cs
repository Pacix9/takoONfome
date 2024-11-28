using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class falasnpcs : MonoBehaviour
{
 
    public Sprite profile;
    public string[] speechText;
    public string actorName;

    public int bahia=0;
    public LayerMask playerLayer;
    public float radious;
    bool onRadious;

    public DialogueControl dc;
    private void Start(){
        dc = FindObjectOfType<DialogueControl>();
    } 
    private void FixedUpdate(){
        Interact();
       

    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.F) && onRadious && bahia==0){
            dc.Speech(profile, speechText, actorName);
            bahia++;
        }

    }

        public void Interact(){
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
            if (hit != null){
                if(dc!=null)
                    onRadious = true;
            }
            else{
                    onRadious = false;
            }
            
        }
        private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
