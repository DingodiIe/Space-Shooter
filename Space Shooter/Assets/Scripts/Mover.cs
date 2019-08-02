using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
     public float speed;

     private Rigidbody rb;
private int difficulty;

     void Start()
     {
          
          difficulty = GameController.difficulty;
          if(difficulty != 2)
               difficulty=1;
    
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
          rb.velocity = transform.forward * (speed * difficulty);
     }
}