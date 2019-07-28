using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
   // public AudioSource MusicSource;
   //  public AudioClip MusicClip;
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int scoreValue;
    
    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        Debug.Log ("Cannot find 'GameController' script");
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag  ("Boundary") || other.CompareTag  ("Enemy"))
        {
            return;
        }
        if (other.CompareTag  ("Player"))
        {
        Instantiate(playerExplosion,other.transform.position, other.transform.rotation);
       gameController.GameOver();
        }
        if (explosion != null)
        {
        Instantiate(explosion, transform.position, transform.rotation);
        }
        
        gameController.AddScore (scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
       // MusicSource.Play();
    }
}
