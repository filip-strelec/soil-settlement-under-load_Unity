using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TlocrtCamera : MonoBehaviour
{
    // Start is called before the first frame update

   
    public float kameraYOffset;
    public Camera glavnaKamera;

    public void ChangeCamera()
    {
        GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();


    if (!programState.kameraOnTlocrt){


        if (programState.sirinaB > programState.duzinaL)
        {

            kameraYOffset = (float)programState.sirinaB + 10;

        }

        else
        {

            kameraYOffset = (float)programState.duzinaL + 10;
        }





        glavnaKamera.transform.localPosition = new Vector3(0, kameraYOffset, 0);
        glavnaKamera.transform.rotation = Quaternion.Euler(90, 0, 0);
        programState.kameraOnTlocrt = true;

}


else{

        glavnaKamera.transform.localPosition = new Vector3 (20,-30,(float)-programState.dubinaZ*1.5f  );
        glavnaKamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        programState.kameraOnTlocrt = false;
        



}

    }
}
