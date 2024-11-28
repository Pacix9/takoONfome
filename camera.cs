using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
   public Transform player;
    private void FixedUpdate()
    {
        
        Vector3 newPosition = player.position + new Vector3(0,1,-10);
        transform.position = newPosition;
        
    }
}
