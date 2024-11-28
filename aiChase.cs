using System.Collections;
using System.Collections.Generic;

using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class aiChase : MonoBehaviour
{
      public GameObject player;
      public float speed;
      public float valorDistance;
    private Animator anim;
      private float distance;
      public float emputecido;
      public float speedEmputecido;
    private EnemyHealth EH;
    public Transform playerTransform;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        EH = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(EH.health > 0){
            anim.SetBool("walk", true);
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(transform.position.x > playerTransform.position.x){
            anim.SetBool("walk", true);
            transform.localScale = new Vector3(4,4,4);
           // transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(transform.position.x < playerTransform.position.x){
            anim.SetBool("walk", true);
                transform.localScale = new Vector3(-4,4,4);
            //transform.position += Vector3.right * speed * Time.deltaTime;
        }


       
        if(distance < valorDistance){
            transform.position= Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            anim.SetBool("walk", true);
            if(distance > emputecido){
            speed = speedEmputecido;
            transform.position= Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            anim.SetBool("run", true);


        }
        
        

        }
       
    }
       
}

    private void runOver(){
        anim.SetBool("run",false);

    }

}
