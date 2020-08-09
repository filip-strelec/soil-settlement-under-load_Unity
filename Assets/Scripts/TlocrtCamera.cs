using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TlocrtCamera : MonoBehaviour
{
    // Start is called before the first frame update


    public float kameraYOffset;
    public Camera glavnaKamera;
    public RectTransform canvasGraphContainer;
        public RectTransform canvasGraphContainerSoil;


    public RectTransform canvasAxisContainerTlocrt;

    public RectTransform koordinatePanel;
    

    public void ChangeCamera()
    {
 GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();
 if ( programState.parametersDefined == true){
       


        if (!programState.kameraOnTlocrt)
        {



            if (programState.sirinaB > programState.duzinaL)
            {

                kameraYOffset = (float)programState.sirinaB + 10;
            }

            else
            {
                kameraYOffset = (float)(2.8 * programState.duzinaL);
            }



  BoxCollider meshRendererTemeljCollider = programState.temeljCollider.GetComponent<BoxCollider>();
        meshRendererTemeljCollider.enabled = true;

            glavnaKamera.transform.localPosition = new Vector3(0, kameraYOffset, 0);
            glavnaKamera.transform.rotation = Quaternion.Euler(90, 0, 0);
            programState.kameraOnTlocrt = true;
            canvasGraphContainer.gameObject.SetActive(false);
            canvasGraphContainerSoil.gameObject.SetActive(false);
            canvasAxisContainerTlocrt.gameObject.SetActive(true);

            koordinatePanel.gameObject.SetActive(true);


        }


        else
        {


            glavnaKamera.transform.position = canvasGraphContainer.transform.position + new Vector3((float)(-programState.dubinaZ * 0.2), 0, (float)-(1.4 * programState.dubinaZ));

            glavnaKamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            programState.kameraOnTlocrt = false;
            canvasGraphContainer.gameObject.SetActive(true);
            canvasGraphContainerSoil.gameObject.SetActive(true);
            canvasAxisContainerTlocrt.gameObject.SetActive(false);
            koordinatePanel.gameObject.SetActive(false);





        }
}
    }
}
