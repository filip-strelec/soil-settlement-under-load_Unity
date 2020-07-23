using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramState : MonoBehaviour
{

// Definiranje parametara zadatka
   public double sirinaB;
   public double duzinaL;
   public double dubinaZ;

   public double sirinaKoordSustavaB;

   public double duzinaKoordSustavaL;

   public double maxIValue;

   public double inkrementMjerenjaZ =0.5f;
   public Vector2 graphSize ;
   public Vector2 CanvasSize;
    public bool kameraOnTlocrt = false;

    public GameObject temeljCollider;

       

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }


   public void RestartProgram(){
Debug.Log("testiram");

   }
}
