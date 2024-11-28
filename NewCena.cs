using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewCena : MonoBehaviour
{
   public string Fasenome;
 private void OnCollisionEnter2D(Collision2D other)
    {

 if (other.collider.CompareTag("Player"))
        {
         Debug.Log("joia");
         SceneManager.LoadScene(Fasenome);

    }

}
}
    