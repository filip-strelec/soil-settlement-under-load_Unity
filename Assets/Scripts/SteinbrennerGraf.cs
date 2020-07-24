using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class IndividualFictionalSquare
{

    public double Width { get; set; }
    public double Length { get; set; }

    public (List<double>depthList, List<double> valueList) SteinbrennerResult {get; set;} 
    
    public IndividualFictionalSquare(double width, double length, (List<double>depthList, List<double> valueList) steinbrennerResult )
    {
        Width = width;
        Length = length;
        SteinbrennerResult = steinbrennerResult;
    }
   
}



public class SteinbrennerGraf : MonoBehaviour
{
     public Sprite krugSprite;
    public RectTransform graphContainer;

    private float SirinaLinije;

    private RectTransform labelTemplateX;

    private RectTransform labelTemplateY;

    public RectTransform templateGridObject;

    public RectTransform PanelTemplateValue;

    public RectTransform backgroundGraph;

 private bool valueShown = false;
    
   private double konacnaDubina = 0;
   


  private  double najvecaVrijednost = 0;
    private double najmanjaVrijednost = 50000;


 

   public void InitializeSteinbrennerGraph(){



    konacnaDubina = 0;


    najvecaVrijednost = 0;
    najmanjaVrijednost = 50000;

// graphContainer = GameObject.Find("GraphContainer").GetComponent<RectTransform>();
GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();

SirinaLinije = (float) (programState.dubinaZ*0.005);
SteinbrennerFormula initializeSteinbrennerCalculation = programManager.GetComponent<SteinbrennerFormula>();
// (List<double>depthList, List<double> valueList) SteinBrennerRezultat= initializeSteinbrennerCalculation.CalculateSteinbrenner(programState.sirinaB, programState.duzinaL); //widthB, lengthL


(List<double>depthList, List<double> valueList) SteinBrennerRezultat;

SteinBrennerRezultat.depthList = new List <double>();

SteinBrennerRezultat.valueList = new List <double>();



//koordinate odabrane tocke
double[] odabranaTocka = programState.koordinateIzracuna;

      
double[] FiktivniTemeljPrvi = {((programState.sirinaB/2)+odabranaTocka[0]),((programState.duzinaL/2)-odabranaTocka[1])};
IndividualFictionalSquare TemeljPrviObjekt = new IndividualFictionalSquare (FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max()));

Debug.Log("sirina 1. fiktivnog temelja: " + TemeljPrviObjekt.Width + "  |||||||      duzina 1. fiktivnog temelja: " + TemeljPrviObjekt.Length);


//Prikazi listu vrijednosti primjer: (za 1. izracun pri dubini 0)
Debug.Log(TemeljPrviObjekt.SteinbrennerResult.valueList[0]);




double[] FiktivniTemeljDrugi ={((programState.sirinaB/2)-odabranaTocka[0]),((programState.duzinaL/2)-odabranaTocka[1])};
IndividualFictionalSquare TemeljDrugiObjekt = new IndividualFictionalSquare (FiktivniTemeljDrugi.Min(), FiktivniTemeljDrugi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljDrugi.Min(),FiktivniTemeljDrugi.Max()));

Debug.Log("sirina 2. fiktivnog temelja: " + TemeljDrugiObjekt.Width + "  |||||||      duzina 2. fiktivnog temelja: " + TemeljDrugiObjekt.Length);



double[] FiktivniTemeljTreci ={((programState.sirinaB/2)+odabranaTocka[0]),((programState.duzinaL/2)+odabranaTocka[1])};
IndividualFictionalSquare TemeljTreciObjekt = new IndividualFictionalSquare (FiktivniTemeljTreci.Min(), FiktivniTemeljTreci.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljTreci.Min(),FiktivniTemeljTreci.Max()));

Debug.Log("sirina 3. fiktivnog temelja: " + TemeljTreciObjekt.Width + "  |||||||      duzina 3. fiktivnog temelja: " + TemeljTreciObjekt.Length);


double[] FiktivniTemeljCetvrti ={((programState.sirinaB/2)-odabranaTocka[0]),((programState.duzinaL/2)+odabranaTocka[1])};
IndividualFictionalSquare TemeljCetvrtiObjekt = new IndividualFictionalSquare (FiktivniTemeljCetvrti.Min(), FiktivniTemeljCetvrti.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljCetvrti.Min(),FiktivniTemeljCetvrti.Max()));
Debug.Log("sirina 4. fiktivnog temelja: " + TemeljCetvrtiObjekt.Width + "  |||||||      duzina 4. fiktivnog temelja: " + TemeljCetvrtiObjekt.Length);


    for(var i = 0; i < TemeljPrviObjekt.SteinbrennerResult.depthList.Count; i ++){
SteinBrennerRezultat.depthList.Add(TemeljPrviObjekt.SteinbrennerResult.depthList[i]);

if (Double.IsNaN(TemeljPrviObjekt.SteinbrennerResult.valueList[i]) ){
TemeljPrviObjekt.SteinbrennerResult.valueList[i] = 0 ;
}
if (Double.IsNaN(TemeljDrugiObjekt.SteinbrennerResult.valueList[i]) ){
TemeljDrugiObjekt.SteinbrennerResult.valueList[i] = 0 ;
}
if (Double.IsNaN(TemeljTreciObjekt.SteinbrennerResult.valueList[i]) ){
TemeljTreciObjekt.SteinbrennerResult.valueList[i] = 0 ;
}
if (Double.IsNaN(TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i]) ){
TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i] = 0 ;
}





double ValueSum = TemeljPrviObjekt.SteinbrennerResult.valueList[i]+TemeljDrugiObjekt.SteinbrennerResult.valueList[i]+TemeljTreciObjekt.SteinbrennerResult.valueList[i]+TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i];
SteinBrennerRezultat.valueList.Add(ValueSum);

// Debug.Log(SteinBrennerRezultat.depthList[i]);
// Debug.Log(SteinBrennerRezultat.valueList[i]);

    }


programState.maxIValue = SteinBrennerRezultat.valueList[0];
SteinBrennerRezultat.depthList.ForEach(i => 
    {
if (i>konacnaDubina){
    konacnaDubina = (double)i;
// Debug.Log(konacnaDubina+"konacna dubina");
        }
    }
);

SteinBrennerRezultat.valueList.ForEach(i => 
    {

// Debug.Log(i + "skoro gotovo");


if (i>najvecaVrijednost){
    najvecaVrijednost = (double)i;
        }


if ( i< najmanjaVrijednost){

  najmanjaVrijednost = (double)i;

}

    }
);

Vector2 lastCircleGameObjectLocation= new Vector2(-10,-10);
for(var i = 0; i < SteinBrennerRezultat.depthList.Count; i ++){
    
 
float xCoordinate = (float) (SteinBrennerRezultat.valueList[i]/najvecaVrijednost)*programState.graphSize[0];
float yCoordinate = (float) (programState.graphSize[1] - (SteinBrennerRezultat.depthList[i]/konacnaDubina)*programState.graphSize[1]);

// Debug.Log("xKOORDINATA:"+xCoordinate);
// Debug.Log("yKOORDINATA:"+yCoordinate);


  GameObject circleGameObject =  CreateCircle(new Vector2 (xCoordinate, yCoordinate));
  Vector2 circleGameObjectLocation = new Vector2(xCoordinate,yCoordinate);

  if (lastCircleGameObjectLocation[0] !=-10){


   CreateDotConnection(lastCircleGameObjectLocation, circleGameObjectLocation);
// Debug.Log("JAKO VAZNO:"+lastCircleGameObjectLocation);
  }
lastCircleGameObjectLocation = circleGameObjectLocation;
    
    }

 
// Debug.Log("---******----**-");


// Debug.Log(SteinBrennerRezultat.depthList.Count);
// Debug.Log(SteinBrennerRezultat.valueList.Count);

// Debug.Log("---******----**-");


 ShowAxisNumbersNGrid();

Debug.Log(programState.graphSize[1] + "graphSize VAZNO");
// Debug.Log(programState.CanvasSize + "CanvasSize");
      backgroundGraph.SetAsFirstSibling();

    }

private void ShowValueListener (Vector2 anchoredPosition){
    
    if (!valueShown ){ showValue( anchoredPosition);
}
    Debug.Log("gwew");}


    private GameObject CreateCircle(Vector2 anchoredPosition){

        GameObject circleObject = new GameObject ("circle",typeof(Image));
        circleObject.transform.SetParent(graphContainer, false);
        circleObject.GetComponent<Image>().sprite = krugSprite;
        RectTransform rectTransform = circleObject.GetComponent<RectTransform>();
        circleObject.GetComponent<Image>().color = new Color(255,0,0, 1f);

        rectTransform.SetAsLastSibling();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.anchorMin = new Vector2 (0,0);
        rectTransform.sizeDelta = new Vector2 ((float)(SirinaLinije+0.5*SirinaLinije),(float)(SirinaLinije+0.5*SirinaLinije));
     rectTransform.anchorMax = new Vector2(0, 0);


    circleObject.AddComponent<Button>();
           circleObject.GetComponent<Button>().onClick.AddListener(()=>ShowValueListener(anchoredPosition));

        return gameObject;
        
    }

private void hidePanel (){


    GameObject panelTemplateClone = GameObject.Find("PanelTemplateValue(Clone)");

    Destroy (panelTemplateClone);
    valueShown= false;


}
private void showValue(Vector2 anchoredPosition){

// PanelTemplateValue = GameObject.Find("PanelTemplateValue").GetComponent<RectTransform>();
valueShown = true;
GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();
RectTransform ValuePanelRectTransform =Instantiate( PanelTemplateValue);

ValuePanelRectTransform.SetParent(graphContainer, false);
ValuePanelRectTransform.gameObject.SetActive(true);
ValuePanelRectTransform.anchoredPosition = anchoredPosition - new Vector2((float)(konacnaDubina*0.1),0);
// ValuePanelRectTransform.localScale = new Vector2(programState.graphSize[0]*0.1f, programState.graphSize[1]*0.1f);
ValuePanelRectTransform.sizeDelta = new Vector2(programState.graphSize[1]*.2f,programState.graphSize[1]*.2f);

GameObject panelTemplateClone = GameObject.Find("PanelTemplateValue(Clone)");
Transform dubinaText =  panelTemplateClone.transform.Find("TextValueDubina");
Transform naprezanjeText =  panelTemplateClone.transform.Find("TextValueI");


dubinaText.GetComponent<Text>().text = "z:"+(programState.graphSize[1]- anchoredPosition[1]).ToString("0.0");
naprezanjeText.GetComponent<Text>().text = "i:"+((anchoredPosition[0]/programState.graphSize[0])*najvecaVrijednost).ToString("0.0000");

double labelsScale =0.02643327*programState.graphSize[1] - 0.04642976;
  if (labelsScale < 0.05){
    labelsScale =0.05;
}
dubinaText.GetComponent<RectTransform>().localScale=(new Vector2((float)labelsScale, (float)labelsScale));
naprezanjeText.GetComponent<RectTransform>().localScale=(new Vector2((float)labelsScale, (float)labelsScale));

dubinaText.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
dubinaText.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);

 Invoke("hidePanel", 2);

}



   private void ShowAxisNumbersNGrid (){
      Debug.Log("SHOWAXISNumbersNGrid INITIALIZED");
GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();

// templateGridObject = GameObject.Find("GridTemplate").GetComponent<RectTransform>();
templateGridObject.gameObject.SetActive(false);

        labelTemplateX = graphContainer.Find("TextLabelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("TextLabelTemplateY").GetComponent<RectTransform>();

        //Dobiveno curve fit metodom
double labelsScale =0.02643327*programState.graphSize[1] - 0.04642976;
  if (labelsScale < 0.05){
    labelsScale =0.05;
}
   
for (int i = 0; i<=5; i++){

   RectTransform labelX = Instantiate(labelTemplateX);
   RectTransform gridX = Instantiate(templateGridObject);
   gridX.SetParent(graphContainer, false);
   gridX.gameObject.SetActive(true);
        labelX.SetParent(graphContainer, false);
        labelX.gameObject.SetActive(true);
        double labelXText = i*(programState.maxIValue/5);
      
        
  
        if (i==0){
        labelX.GetComponent<Text>().text=labelXText.ToString(" ");


        }

        else{        labelX.GetComponent<Text>().text=labelXText.ToString("0.00");
        
}
        float labelXXposition = (i/5f*programState.graphSize[0]);
        
        // Debug.Log(programState.graphSize[1] + "graphSize ______________YYY VAZNO");
        // Debug.Log(programState.graphSize[0] + "graphSize ______XXXXVAZNO");

 labelX.anchoredPosition= new Vector2(labelXXposition,(float)(programState.graphSize[1]+(2.3*labelsScale)));
labelX.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);

gridX.anchoredPosition = new Vector2(labelXXposition,(programState.graphSize[1]/2));
gridX.localScale =new Vector2((float)(labelsScale/8), programState.graphSize[1]);
gridX.SetAsFirstSibling();
}


for (int i = 0; i<=10; i++){

   RectTransform labelY = Instantiate(labelTemplateY);
        labelY.SetParent(graphContainer, false);
        labelY.gameObject.SetActive(true);
        float dubina = programState.graphSize[1];
        double labelYText = i*(dubina/10);

 RectTransform gridY = Instantiate(templateGridObject);
   gridY.SetParent(graphContainer, false);
   gridY.gameObject.SetActive(true);

       
        float labelYYposition = dubina - (i/10f*dubina);
        // Debug.Log(programState.graphSize[1] + "graphSize ______________YYY VAZNO");
        // Debug.Log(programState.graphSize[0] + "graphSize ______XXXXVAZNO");

 labelY.anchoredPosition= new Vector2(0,labelYYposition);


 if (i==0){
        labelY.GetComponent<Text>().text="0";
               labelY.anchoredPosition= new Vector2((float)(-0.01*dubina),(float)(programState.graphSize[1]+(0.85*labelsScale)));


  }
  else {

              labelY.GetComponent<Text>().text=labelYText.ToString("0.00");
               labelY.anchoredPosition= new Vector2((float)(-0.01*dubina),labelYYposition);


  }
 
//  (float)(programState.graphSize[1]+programState.graphSize[1]*0.1));
labelY.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);


gridY.anchoredPosition = new Vector2((programState.graphSize[0]/2),labelYYposition);
gridY.localScale =new Vector2(programState.graphSize[0],(float)labelsScale/8);
gridY.SetAsFirstSibling();

}

    }



private static float GetAngleFromVectorFloat(Vector3 dir) {



            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }




        private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
            GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1, 0.8f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB)*1f;
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
         rectTransform.SetAsFirstSibling();
        rectTransform.sizeDelta = new Vector2(distance, (float)(SirinaLinije));
        rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));

        //   gameObject.AddComponent<Button>();
        //    gameObject.GetComponent<Button>().onClick.AddListener(()=>TestScript());
        

        // Debug.Log(dotPositionA+ "positiondotA");
        // Debug.Log(dotPositionB+ "positionDotB");

        // Debug.Log(gameObject+ "gameObject");

        // Debug.Log(rectTransform+ "rectTransform");
        // Debug.Log(dir+ "dir");
        // Debug.Log(distance+ "distance");
     
    }
}


