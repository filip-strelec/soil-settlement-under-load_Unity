using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitalizeProgram : MonoBehaviour
{
    public Material dryGroundMaterial;
    public Material foundationMaterial;

    public Button gumbZaRotacijuKamere;

    public Camera glavnaKamera;

    //komponente za graf

      private RectTransform canvasGraphContainer;
      private RectTransform windowGraph;
      private RectTransform graphContainer;



    public void InitializeProgram()
    {

        double sirinaTemelja = 0;
        double duzinaTemelja = 0;
        double dubinaMjerenjaParametar = 0;
        double inkrementMjerenja =0;
        double brojMjerenja = 0;
        //referenca na program manager u kojem su sačuvani parametri
        GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();

        // transform.Find("Text").GetComponent<Text>().text = text;


        //dobijanje inputa iz input filedova

        InputField sirinaInputB = GameObject.Find("InputFieldSirinaB").GetComponent<InputField>();
        InputField duzinaInputL = GameObject.Find("InputFieldDuzinaL").GetComponent<InputField>();
        InputField dubinaInputParametar = GameObject.Find("InputFieldDubinaZ").GetComponent<InputField>();
        InputField brojMjerenjaInputField = GameObject.Find("InputFieldBrojMjerenja").GetComponent<InputField>();

      


        //definiranje paramentara u programState-u


        bool canConvertSirina = double.TryParse(sirinaInputB.text, out sirinaTemelja);
        programState.sirinaB = sirinaTemelja;

        bool canConvertDuzina = double.TryParse(duzinaInputL.text, out duzinaTemelja);
        programState.duzinaL = duzinaTemelja;

        bool canConvertDubina = double.TryParse(dubinaInputParametar.text, out dubinaMjerenjaParametar);
        programState.dubinaZ = dubinaMjerenjaParametar * sirinaTemelja;


         bool canConvertBrojMjerenja = double.TryParse(brojMjerenjaInputField.text, out brojMjerenja);
        programState.InkrementMjerenjaZ = 1/brojMjerenja;



        if (programState.sirinaB != 0 && programState.duzinaL != 0 && programState.dubinaZ != 0)
        {

            //inicijalizacija definiranja temelja
            
             programState.graphSize = new Vector2 ((float) (0.65*programState.dubinaZ), (float)programState.dubinaZ);
             programState.CanvasSize = programState.graphSize + 0.6f*programState.graphSize;

            GameObject temelj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            temelj.transform.localPosition = new Vector3(0, 0, 0);
            temelj.transform.localScale = new Vector3((float)programState.sirinaB, 0.1f, (float)programState.duzinaL);
            temelj.GetComponent<MeshRenderer>().material = foundationMaterial;

            GameObject tlo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            tlo.transform.localPosition = new Vector3(0, -(float)programState.dubinaZ / 2, 0);
            tlo.transform.localScale = new Vector3((float)programState.sirinaB, (float)programState.dubinaZ, (float)programState.duzinaL);
            tlo.GetComponent<MeshRenderer>().material = dryGroundMaterial;

            gumbZaRotacijuKamere.GetComponent<Image>().enabled = true;

            GameObject canvasParametri = GameObject.Find("CanvasParametri");
            canvasParametri.SetActive(false);




        //definiranje dimenzija komponenata canvasa za Steinbrenner-a


            canvasGraphContainer = GameObject.Find("CanvasGraph").GetComponent<RectTransform>();
            windowGraph = GameObject.Find("WindowGraph").GetComponent<RectTransform>();
            graphContainer = GameObject.Find("GraphContainer").GetComponent<RectTransform>();

         

   canvasGraphContainer.sizeDelta =programState.CanvasSize + new Vector2 (1, 0);;
   windowGraph.sizeDelta = programState.CanvasSize + new Vector2 (1, 0);
   graphContainer.sizeDelta = programState.graphSize;
//    graphContainer.anchoredPosition()
graphContainer.anchorMin = new Vector2(0.5f, 0.5f);
graphContainer.anchorMax = new Vector2(0.5f, 0.5f);


float xOffset = (float) ((programState.CanvasSize[0]/2+programState.sirinaB/2)+programState.dubinaZ*0.35);
float yOffset = (float) (-programState.graphSize[1]/2) ;
float zOffset = (float)(-programState.duzinaL/2);

   canvasGraphContainer.position = new Vector3(xOffset, yOffset ,zOffset );



           glavnaKamera.transform.position = canvasGraphContainer.transform.position + new Vector3((float)(-programState.dubinaZ*0.2),0,(float)-(1.4*programState.dubinaZ));

 GameObject mainCamera = GameObject.Find("Main Camera");
        CameraMovement mainCameraState = mainCamera.GetComponent<CameraMovement>();
        mainCameraState.panSpeed = (float)programState.dubinaZ*1.4f;
        



        };

        Debug.Log("___________");

        Debug.Log(programState.duzinaL);
        Debug.Log(programState.sirinaB);
        Debug.Log(programState.dubinaZ);











    }
}
