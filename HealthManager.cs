using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount;
    public player PH;
    public EnemyHealth EH;


    // Start is called before the first frame update
    void Start()
    {
        PH = GetComponent<player>();   
        EH = GetComponent<EnemyHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
        PH.healthP = healthAmount;
       
        if(healthAmount <= 80){
           
            TakeDamage(20);
           
        }
        if(healthAmount <= 60){
           
            TakeDamage(40);
           
        }
        if(healthAmount <= 40){
        
            TakeDamage(60);
           
        }
        if(healthAmount <= 20){
      
            TakeDamage(80);
           
        }
        if(healthAmount >= 0){
            TakeDamage(100);
        }

    }


    public void TakeDamage(float damage){
         healthAmount  -= damage;
         healthBar.fillAmount = healthAmount / 200f;

    }
    public void HealP(float healingAmount){
       healthAmount += healingAmount;
       healthAmount = Mathf.Clamp(healthAmount,0,200);
       healthBar.fillAmount = healingAmount / 200f;

    }
}
