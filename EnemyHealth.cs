using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float EDamage;
    // Start is called bef/
    public float health = 0;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(health <= 0){
        Debug.Log("Morto");
        anim.SetBool("death", true);
        }

        if (health == 30 ){
            anim.SetBool("hit", true);
           
        }
        else if (health == 10 ){
            anim.SetBool("hit", true);
           
        }

        

       
       
    }
    public void stopDeath(){
       anim.SetBool("death", false);

    }
    public void stophit(){
       anim.SetBool("hit", false);

    }
     

       

}