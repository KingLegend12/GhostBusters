using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProbabilityText : MonoBehaviour
{
        public Game clicked;

     public TextMeshPro probability;
     public double probabilitycount = 0; 
    
    void Start()
    {
        clicked = FindObjectOfType(typeof(Game)) as Game;
        probabilitycount= 0.021;
    }

    // Update is called once per frame
    void Update()
    {   
        CalculateBayesianProbability(clicked.lastcheckedX, clicked.lastcheckedY, clicked.gx, clicked.gy);
        probability.text =  probabilitycount.ToString();
    }
   
   
    void CalculateBayesianProbability(int lastcheckedx, int lastcheckedy, int ghostx, int ghosty) 
    {
        int Distance=0, DistanceX=0, DistanceY=0;
        
                
                 
                     
                        probabilitycount= clicked.JointTableProbability("red", 0);
                        
                 /*else {
                      if(x>=ghostx) DistanceX = x-ghostx;
                             else DistanceX = ghostx-x;
                    if(y>=ghosty) DistanceY = y-ghosty;
                             else DistanceX = ghosty-y;
                    Distance=DistanceX+DistanceY;
                     probabilitycount = clicked.JointTableProbability("orange", Distance);  
                    
                 }*/
     }
}
       
    

