using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class SteinbrennerFormula : MonoBehaviour
{



    public (List<double>list1, List<double> list2) CalculateSteinbrenner(double widthB, double lengthL){

 GameObject programManager = GameObject.Find("ProgramManager");
 ProgramState programState = programManager.GetComponent<ProgramState>();

 
   
// Debug.Log(programState.dubinaZ+"zadana dubina");



List<double> depthList = new List <double>();
List<double> valueList = new List<double> ();

            for (double i = 0.0; i < programState.dubinaZ; i += programState.inkrementMjerenjaZ)
{


double trenutnaDubinaZ = i;

    double firstFraction = (double)Math.Atan((lengthL * widthB) / (trenutnaDubinaZ*Math.Sqrt(Math.Pow(lengthL,2) + Math.Pow(widthB,2)+ Math.Pow(trenutnaDubinaZ ,2))));
    double secondFraction = (double)(lengthL * widthB * trenutnaDubinaZ) / (Math.Sqrt(Math.Pow(lengthL , 2) + Math.Pow(widthB, 2) + Math.Pow(trenutnaDubinaZ, 2)));
    double thirdFraction = (double)(((1) / (Math.Pow(lengthL ,2) + Math.Pow(trenutnaDubinaZ,2))) + ((1) / (Math.Pow(widthB,2) + Math.Pow(trenutnaDubinaZ,2))));
    double steinbrennerIzracun = (double)((1) / (2 * Math.PI)) * (firstFraction + secondFraction * thirdFraction);

    // Debug.Log("IDEEEMOOOOOOO___________IDEMOOO: "+trenutnaDubinaZ);
    // Debug.Log("+++++++_______++++++++: "+steinbrennerIzracun);
    depthList.Add(trenutnaDubinaZ);
    valueList.Add(steinbrennerIzracun);

    double razlikaDubine = programState.dubinaZ- trenutnaDubinaZ;

//     if (razlikaDubine<= programState.inkrementMjerenjaZ){

//         trenutnaDubinaZ = programState.dubinaZ;

//    firstFraction = (double)Math.Atan((programState.duzinaL * programState.sirinaB) / (trenutnaDubinaZ*Math.Sqrt(Math.Pow(programState.duzinaL,2) + Math.Pow(programState.sirinaB,2)+ Math.Pow(trenutnaDubinaZ,2))));
//     secondFraction = (double)(programState.duzinaL * programState.sirinaB * trenutnaDubinaZ) / (Math.Sqrt(Math.Pow(programState.duzinaL, 2) + Math.Pow(programState.sirinaB, 2) + Math.Pow(trenutnaDubinaZ, 2)));
//      thirdFraction = (double)(((1) / (Math.Pow(programState.duzinaL,2) + Math.Pow(trenutnaDubinaZ,2))) + ((1) / (Math.Pow(programState.sirinaB,2) + Math.Pow(trenutnaDubinaZ,2))));
//     steinbrennerIzracun = (double)((1) / (2 * Math.PI)) * (firstFraction + secondFraction * thirdFraction);

//     // Debug.Log("Zadnje: "+trenutnaDubinaZ);
//     // Debug.Log("+++++++_______++++++++: "+steinbrennerIzracun);

//      depthList.Add(trenutnaDubinaZ);
//     valueList.Add(steinbrennerIzracun);

//     Debug.Log(trenutnaDubinaZ);
//     Debug.Log(steinbrennerIzracun);


//     }

}



return (depthList, valueList); 

    }




}
