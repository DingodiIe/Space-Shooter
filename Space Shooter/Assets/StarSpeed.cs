using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpeed : MonoBehaviour
{
    private int checkWin;
    // Start is called before the first frame update
    void Start()
    {
 
        
      
    }
    // Update is called once per frame
    void Update()
    {
        checkWin = GameController.winSpeed;

        if(checkWin ==80){
            ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.simulationSpeed = 20;
      

       
        
        }

    
        }

    }
        

    

  // checkWin = GameController.winSpeed;

   //     if(checkWin ==80){
 //           ParticleSystem ps = GetComponent<ParticleSystem>();
  //      var main = ps.main;
//        yield return new WaitForSeconds(1);
 //       main.simulationSpeed = main.simulationSpeed*2;
  //      if(main.simulationSpeed >= 20){
   //         stopSpeed = 1;
        

    
        

    