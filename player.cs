using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class player : MonoBehaviour
{

private float Ehealth;
    public bool pulando = false;
    public int movendo;
    public float healthP;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;
    public GameObject attackPoints;
    public float radius;
    public LayerMask enemies;
    public float damage;
    EnemyHealth EH;
    public Image HealthDisplay;



    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
         EH = GetComponent<EnemyHealth>();
          
       
   
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Pulo();
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
            Speed = 3;

        }
        if (Input.GetAxis("Fire1") > 0f)
        {
            anim.SetBool("attack", true);
            

        }
   

    }

    private void attack(){
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoints.transform.position, radius,enemies);
        foreach (Collider2D enemyGameobject in enemy){
            Debug.Log("Hitado");
            enemyGameobject.gameObject.GetComponent<EnemyHealth>().health -= damage;
        }

    }

    private void AttackOver()
    {
        anim.SetBool("attack", false);
        

    }
    
    private void OnDrawGizmos(){
            Gizmos.DrawWireSphere(attackPoints.transform.position,radius);

        }

    private void Move()
        {
            UnityEngine.Vector3 movement = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;

            //DIREITA
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0f, 0f, 0f);
            anim.SetBool("walk", true);
            Speed = 3;
            movendo = 1;
        }
            //ESQUERDA
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0f, 180f, 0f);
            anim.SetBool("walk", true);
            Speed = 3;
            movendo = 2;
        }

        if (Input.GetAxis("Run") > 0f) {
            Speed = 8;
            anim.SetBool("run", true);
        }
        else {
            anim.SetBool("run", false);
        }
    }

    private void Pulo()
        {
        if (Input.GetButtonDown("Jump") && pulando == false)
        {
            rig.AddForce(new UnityEngine.Vector2(0f, JumpForce), ForceMode2D.Impulse);
            pulando = true;
            anim.SetBool("jump", true);


        }
        else
        {
            anim.SetBool("jump", false);

        }
        //não sei oque eu fiz, mas deu certo :D
        // ou quase




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            pulando = false;
        }
        else if (collision.gameObject.CompareTag("Maca"))
        {
            Destroy(collision.gameObject);
            healthP += 25;
            healthP = Mathf.Clamp(healthP,0,100);
            HealthDisplay.fillAmount = healthP;

        }
        else if (collision.gameObject.name.Equals("cana_de_acucar1"))
        {
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name.Equals("cana_de_acucar2"))
        {
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name.Equals("cana_de_acucar3"))
        {
            Destroy(collision.gameObject);

        }
    
        if (collision.gameObject.CompareTag("Enemy"))
    {
        // Acesse o componente EnemyHealth diretamente no inimigo
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
       if (enemyHealth != null && enemyHealth.health > 0)
        {
            healthP -= 20; // Subtraia vida do jogador
            HealthDisplay.fillAmount = healthP / 100f;
            Debug.Log("Hitado jogador");
        }
        if (healthP <=0){
            Application.LoadLevel(Application.loadedLevel);
        }
    }
        
        }
    }
      
    
    
        
    
    
