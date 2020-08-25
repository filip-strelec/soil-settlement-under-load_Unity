using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class InitalizeProgram : MonoBehaviour
{
    public Material dryGroundMaterial;
    public Material foundationMaterial;

    public Button gumbZaRotacijuKamere;

    public Camera glavnaKamera;

    

    //komponente za grafove 

    private RectTransform canvasGraphContainer;
    private RectTransform canvasGraphContainerSoil;
    private RectTransform canvasGraphContainerDeformation;

    private RectTransform windowGraph;
    private RectTransform windowGraphSoil;
    private RectTransform windowGraphDeformation;

    private RectTransform graphContainer;
    private RectTransform graphContainerSoil;
    private RectTransform graphContainerDeformation;




    // Komponente za koordinatni sustav tlocrta

    private RectTransform canvasAxisTlocrt;

    private RectTransform windowAxisTlocrt;
    private RectTransform axisContainerTlocrt;

    private RectTransform templateGridObject;

    private RectTransform labelTemplateXTlocrt;

    private RectTransform labelTemplateYTlocrt;

 

    public Text duzinaLText;
    public Text sirinaBText;

//parametri mjerenja

public Text duzinaLTextMjerenje;

public Text sirinaBTextTextMjerenje;

public Text dubinaZTextTextMjerenje;

public Text  InkrementMjerenjaTextTextMjerenje;

public Text  PovrNaprezanjeTextTextMjerenje;
public GameObject CanvasButtons;

public void showButtonPanels (){

    GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();

 if  (programState.sirinaB != 0 && programState.duzinaL != 0 && programState.brojSlojeva <= 9)
        {

      CanvasButtons.gameObject.SetActive(true);
      
          }




}



    private void ShowAxisNumbersNGrid()
    {

        GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();

        templateGridObject = GameObject.Find("GridTemplateTlocrt").GetComponent<RectTransform>();
        templateGridObject.gameObject.SetActive(false);

        labelTemplateXTlocrt = axisContainerTlocrt.Find("TextLabelTemplateXTlocrt").GetComponent<RectTransform>();
        labelTemplateYTlocrt = axisContainerTlocrt.Find("TextLabelTemplateYTlocrt").GetComponent<RectTransform>();

        //Dobiveno odokativno
        double labelsScale = 0.016 * programState.sirinaKoordSustavaB;
        if (labelsScale < 0.05)
        {
            labelsScale = 0.05;
        }
        double inkrementLabelXText = programState.sirinaKoordSustavaB / 10;
        double pocetnaLabelXVrijednost = -inkrementLabelXText * 5;
        for (int i = 0; i < 11; i++)
        {

            RectTransform labelX = Instantiate(labelTemplateXTlocrt);
            RectTransform gridX = Instantiate(templateGridObject);
            gridX.SetParent(axisContainerTlocrt, false);
            gridX.gameObject.SetActive(true);
            labelX.SetParent(axisContainerTlocrt, false);
            labelX.gameObject.SetActive(true);


            double labelXText = pocetnaLabelXVrijednost + i * inkrementLabelXText;





            labelX.GetComponent<Text>().text = labelXText.ToString("0.0");


            float labelXXposition = (i / 10f * (float)(programState.sirinaKoordSustavaB));

            // Debug.Log(programState.graphSize[1] + "graphSize ______________YYY VAZNO");
            // Debug.Log(programState.graphSize[0] + "graphSize ______XXXXVAZNO");

            labelX.anchoredPosition = new Vector2(labelXXposition, (float)(programState.duzinaKoordSustavaL + (3 * labelsScale)));


            labelX.localScale = new Vector2((float)labelsScale, (float)labelsScale);

            gridX.anchoredPosition = new Vector2(labelXXposition, (float)(programState.duzinaKoordSustavaL / 2));

            if (i == 5)
            {

                gridX.localScale = new Vector2((float)(labelsScale / 2), (float)programState.duzinaKoordSustavaL);

            }

            else
            {
                gridX.localScale = new Vector2((float)(labelsScale / 5), (float)programState.duzinaKoordSustavaL);


            }
            gridX.SetAsFirstSibling();
        }


        double inkrementLabelYText = programState.duzinaKoordSustavaL / 10;
        double pocetnaLabelYVrijednost = -inkrementLabelYText * 5;

        for (int i = 0; i < 11; i++)
        {

            RectTransform labelY = Instantiate(labelTemplateYTlocrt);
            RectTransform gridY = Instantiate(templateGridObject);
            gridY.SetParent(axisContainerTlocrt, false);
            gridY.gameObject.SetActive(true);
            labelY.SetParent(axisContainerTlocrt, false);
            labelY.gameObject.SetActive(true);


            double labelYText = pocetnaLabelYVrijednost + i * inkrementLabelYText;





            labelY.GetComponent<Text>().text = labelYText.ToString("0.0");


            float labelYYposition = (i / 10f * (float)(programState.duzinaKoordSustavaL));

            // Debug.Log(programState.graphSize[1] + "graphSize ______________YYY VAZNO");
            // Debug.Log(programState.graphSize[0] + "graphSize ______XXXXVAZNO");

            labelY.anchoredPosition = new Vector2((float)((0.1 * labelsScale)), labelYYposition);


            labelY.localScale = new Vector2((float)labelsScale, (float)labelsScale);

            gridY.anchoredPosition = new Vector2((float)(programState.sirinaKoordSustavaB / 2), labelYYposition);

            if (i == 5)
            {

                gridY.localScale = new Vector2((float)programState.sirinaKoordSustavaB, (float)(labelsScale / 2));

            }

            else
            {
                gridY.localScale = new Vector2((float)programState.sirinaKoordSustavaB, (float)(labelsScale / 5));


            }
            gridY.SetAsFirstSibling();
        }


    }



public void InitializeValues(){


        double sirinaTemelja = 0;
        double duzinaTemelja = 0;
        double dubinaMjerenjaParametar = 20;

        double brojMjerenja = 0.1f;
        double povrNapr = 100f;
        int brojSlojeva = 1;


     GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();





        //dobijanje inputa iz input filedova

        InputField sirinaInputB = GameObject.Find("InputFieldSirinaB").GetComponent<InputField>();
        InputField duzinaInputL = GameObject.Find("InputFieldDuzinaL").GetComponent<InputField>();
        InputField dubinaInputParametar = GameObject.Find("InputFieldDubinaZ").GetComponent<InputField>();
        InputField brojMjerenjaInputField = GameObject.Find("InputFieldBrojMjerenja").GetComponent<InputField>();
        InputField povrsinskoNaprezanje = GameObject.Find("InputFieldPovrsinskoNaprezanje").GetComponent<InputField>();
        InputField brojSlojevaInput = GameObject.Find("InputFieldBrojSlojeva").GetComponent<InputField>();



        //definiranje paramentara u programState-u

      
programState.inkrementMjerenjaZ = 0.1f;
programState.dubinaZ = 20f;
programState.povrsinskoNaprezanje = povrNapr;

programState.brojSlojeva = brojSlojeva;



        bool canConvertSirina = double.TryParse(sirinaInputB.text, out sirinaTemelja);
        programState.sirinaB = sirinaTemelja;

        bool canConvertDuzina = double.TryParse(duzinaInputL.text, out duzinaTemelja);
        programState.duzinaL = duzinaTemelja;

        bool canConvertDubina = double.TryParse(dubinaInputParametar.text, out dubinaMjerenjaParametar);

        if (canConvertDubina){
        programState.dubinaZ = dubinaMjerenjaParametar ;
}

        bool canConvertBrojMjerenja = double.TryParse(brojMjerenjaInputField.text, out brojMjerenja);
        if (canConvertBrojMjerenja){
        programState.inkrementMjerenjaZ =  brojMjerenja*0.01;
        }

        
        bool canConvertPovNapr = double.TryParse(povrsinskoNaprezanje.text, out povrNapr);
        if (canConvertPovNapr){
        programState.povrsinskoNaprezanje =  povrNapr;
        }

         
        bool canConvertBrojSlojeva = Int32.TryParse(brojSlojevaInput.text, out brojSlojeva);
        if (canConvertBrojSlojeva){
        programState.brojSlojeva =  brojSlojeva;
        }





        programState.sirinaKoordSustavaB =  Math.Ceiling(programState.sirinaB * 3)+(5-(Math.Ceiling(programState.sirinaB * 3)%5));
        programState.duzinaKoordSustavaL = Math.Ceiling(programState.duzinaL * 3)+(5-(Math.Ceiling(programState.sirinaB * 3)%5));
}



    public void InitializeProgram()
    {



        //referenca na program manager u kojem su sačuvani parametri
        GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();
programState.initialStart = true;
        // transform.Find("Text").GetComponent<Text>().text = text;
if (programState.youngDefined){

       

Debug.Log(programState.brojSlojeva+"gegergEE");
programState.parametersDefined = true;
            //inicijalizacija definiranja temelja

duzinaLText.text ="L(m): "+programState.duzinaL.ToString("0.00");
sirinaBText.text ="B(m): "+ programState.sirinaB.ToString("0.00");



duzinaLTextMjerenje.text ="L(m): "+programState.duzinaL.ToString("0.00");
sirinaBTextTextMjerenje.text ="B(m): "+ programState.sirinaB.ToString("0.00");
dubinaZTextTextMjerenje.text="Dubina z(m):"+programState.dubinaZ.ToString("0.00") ;
InkrementMjerenjaTextTextMjerenje.text="Deblj. lamele(m):"+programState.inkrementMjerenjaZ.ToString("0.00");
PovrNaprezanjeTextTextMjerenje.text="Povr. napr.(kPa):"+programState.povrsinskoNaprezanje.ToString("0.00");





            programState.graphSize = new Vector2((float)(0.65 * programState.dubinaZ), (float)programState.dubinaZ);
            programState.CanvasSize = programState.graphSize + 0.8f * programState.graphSize;

            GameObject temelj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            temelj.transform.localPosition = new Vector3(0, 0, 0);
            temelj.transform.localScale = new Vector3((float)programState.sirinaB, 0.1f, (float)programState.duzinaL);
            temelj.GetComponent<MeshRenderer>().material = foundationMaterial;
            temelj.GetComponent<BoxCollider>().enabled = false;
            temelj.tag ="temeljTag";


          

            programState.temeljCollider = GameObject.CreatePrimitive(PrimitiveType.Cube);
            programState.temeljCollider.transform.localPosition = new Vector3(0, 0, 0);
            programState.temeljCollider.transform.localScale = new Vector3((float)programState.sirinaKoordSustavaB, 0.15f, (float)programState.duzinaKoordSustavaL);
            Renderer meshRendererTemeljCollider = programState.temeljCollider.GetComponent<Renderer>();
            meshRendererTemeljCollider.enabled = false;


            // GameObject tlo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // tlo.transform.localPosition = new Vector3(0, -(float)programState.dubinaZ / 2, 0);
            // tlo.transform.localScale = new Vector3((float)programState.sirinaB, (float)programState.dubinaZ, (float)programState.duzinaL);
            // tlo.GetComponent<MeshRenderer>().material = dryGroundMaterial;
            // tlo.GetComponent<BoxCollider>().enabled = false;


         GameObject canvasDubina = GameObject.Find("CanvasDubina");
            canvasDubina.transform.localPosition = new Vector3((float)((programState.sirinaB/2)+(programState.dubinaZ*0.05)), -(float)programState.dubinaZ / 2,  (float)(-0.5*programState.duzinaL));
            canvasDubina.transform.localScale = new Vector2((float)(programState.dubinaZ*0.1), (float)programState.dubinaZ);



            gumbZaRotacijuKamere.gameObject.SetActive(true);

                        





            //definiranje dimenzija i lokacije koordinatnog sustava temelja


            canvasAxisTlocrt = GameObject.Find("CanvasAxisTlocrt").GetComponent<RectTransform>();
            windowAxisTlocrt = GameObject.Find("WindowTlocrt").GetComponent<RectTransform>();
            axisContainerTlocrt = GameObject.Find("AxisContainerTlocrt").GetComponent<RectTransform>();

            canvasAxisTlocrt.position = new Vector3(0, (float)0.08, 0);
            canvasAxisTlocrt.rotation = Quaternion.Euler(90, 0, 0);
            canvasAxisTlocrt.sizeDelta = new Vector2((float)(1.2 * programState.sirinaKoordSustavaB), (float)(1.2 * programState.duzinaKoordSustavaL));

            windowAxisTlocrt.sizeDelta = new Vector2((float)(1.2 * programState.sirinaKoordSustavaB), (float)(1.2 * programState.duzinaKoordSustavaL));


            axisContainerTlocrt.sizeDelta = new Vector2((float)programState.sirinaKoordSustavaB, (float)programState.duzinaKoordSustavaL);
            axisContainerTlocrt.anchorMin = new Vector2(0.5f, 0.5f);
            axisContainerTlocrt.anchorMax = new Vector2(0.5f, 0.5f);


            //definiranje dimenzija komponenata za grafove (needs refactoring)


            canvasGraphContainer = GameObject.Find("CanvasGraph").GetComponent<RectTransform>();
            canvasGraphContainerSoil = GameObject.Find("CanvasGraphSoil").GetComponent<RectTransform>();
            canvasGraphContainerDeformation = GameObject.Find("CanvasGraphDeformation").GetComponent<RectTransform>();


            windowGraph = GameObject.Find("WindowGraph").GetComponent<RectTransform>();
            windowGraphSoil = GameObject.Find("WindowGraphSoil").GetComponent<RectTransform>();
            windowGraphDeformation = GameObject.Find("WindowGraphDeformation").GetComponent<RectTransform>();


            graphContainer = GameObject.Find("GraphContainer").GetComponent<RectTransform>();
            graphContainerSoil = GameObject.Find("GraphContainerSoil").GetComponent<RectTransform>();
            graphContainerDeformation = GameObject.Find("GraphContainerDeformation").GetComponent<RectTransform>();






            canvasGraphContainer.sizeDelta = programState.CanvasSize + new Vector2(1, 0); ;
            windowGraph.sizeDelta = programState.CanvasSize + new Vector2(1, 0);
            graphContainer.sizeDelta = programState.graphSize;


            canvasGraphContainerSoil.sizeDelta = programState.CanvasSize + new Vector2(1, 0); ;
            windowGraphSoil.sizeDelta = programState.CanvasSize + new Vector2(1, 0);
            graphContainerSoil.sizeDelta = programState.graphSize;


            canvasGraphContainerDeformation.sizeDelta = programState.CanvasSize + new Vector2(1, 0); ;
            windowGraphDeformation.sizeDelta = programState.CanvasSize + new Vector2(1, 0);
            graphContainerDeformation.sizeDelta = programState.graphSize;


            //    graphContainer.anchoredPosition()
            graphContainer.anchorMin = new Vector2(0.5f, 0.5f);
            graphContainer.anchorMax = new Vector2(0.5f, 0.5f);

            graphContainerSoil.anchorMin = new Vector2(0.5f, 0.5f);
            graphContainerSoil.anchorMax = new Vector2(0.5f, 0.5f);

             graphContainerDeformation.anchorMin = new Vector2(0.5f, 0.5f);
            graphContainerDeformation.anchorMax = new Vector2(0.5f, 0.5f);


            float xOffset = (float)((programState.CanvasSize[0] / 2 + programState.sirinaB / 2)+0.5 );
            float yOffset = (float)(-programState.graphSize[1] / 2);
            float zOffset = (float)(-programState.duzinaL / 2);

            canvasGraphContainer.position = new Vector3(xOffset, yOffset, zOffset);
            canvasGraphContainerSoil.position = new Vector3(xOffset+(2*(programState.CanvasSize[0]+1)), yOffset, zOffset);
            canvasGraphContainerDeformation.position = new Vector3(xOffset+(programState.CanvasSize[0]+1), yOffset, zOffset);




            glavnaKamera.transform.position = canvasGraphContainerDeformation.transform.position + new Vector3(0, 0, (float)-(1.4 * programState.dubinaZ));

            GameObject mainCamera = GameObject.Find("Main Camera");
            CameraMovement mainCameraState = mainCamera.GetComponent<CameraMovement>();
            mainCameraState.panSpeed = (float)programState.duzinaL * 1.3f;


            ShowAxisNumbersNGrid();




        Debug.Log("___________");

        Debug.Log("Definirana duzina L " + programState.duzinaL);
        Debug.Log("Definirana sirina B " + programState.sirinaB);
        Debug.Log("Definirana dubina Z " + programState.dubinaZ);


        Debug.Log("___________");




GameObject canvasParametri = GameObject.Find("CanvasParametri");
            canvasParametri.SetActive(false);




    }

}

}
