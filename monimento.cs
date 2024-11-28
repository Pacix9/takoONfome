using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monimento : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
 
 void Update () 
 {
     transform.position = new Vector3 (Player.position.x, Player.position.y, -10); 
 }
}
