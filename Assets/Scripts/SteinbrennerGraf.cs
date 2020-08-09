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

    public    GameObject  exportToCsvButton;


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
programState.clearGraph();




SirinaLinije = (float) (programState.dubinaZ*0.005);
SteinbrennerFormula initializeSteinbrennerCalculation = programManager.GetComponent<SteinbrennerFormula>();


(List<double>depthList, List<double> valueList) SteinBrennerRezultat;

SteinBrennerRezultat.depthList = new List <double>();

SteinBrennerRezultat.valueList = new List <double>();



//koordinate odabrane tocke
double[] odabranaTocka = programState.koordinateIzracuna;

odabranaTocka[0] = Math.Abs(odabranaTocka[0]);
odabranaTocka[1] = Math.Abs(odabranaTocka[1]);

programState.maxIValue = 0;

//Logika za točku koja je unutar temelja:


// Debug.Log("_*-*-*-*-**-*-*-");
// Debug.Log(odabranaTocka[0]+":"+odabranaTocka[1]);
// Debug.Log(programState.sirinaB);
// Debug.Log(programState.duzinaL);
// Debug.Log("_*-*-*-*-**-*-*-");
//Slučaj za točku unutar temelja

if ( odabranaTocka[0]<=programState.sirinaB/2 && odabranaTocka[1]<=programState.duzinaL/2){


double[] FiktivniTemeljPrvi = {((programState.sirinaB/2)+odabranaTocka[0]),((programState.duzinaL/2)-odabranaTocka[1])};
IndividualFictionalSquare TemeljPrviObjekt = new IndividualFictionalSquare (FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max()));

Debug.Log("sirina 1. fiktivnog temelja: " + TemeljPrviObjekt.Width + "  |||||||      duzina 1. fiktivnog temelja: " + TemeljPrviObjekt.Length);


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
// Debug.Log(SteinBrennerRezultat.valueList[i] + "VAZNO unutar temelja");

    }






}


else{
    
    Debug.Log("Točka je van TEMELJA!!");
int dotTypeLocation = 0;

    double[] FiktivniTemeljPrvi = {((programState.sirinaB/2)+odabranaTocka[0]),((programState.duzinaL/2)+odabranaTocka[1])};
IndividualFictionalSquare TemeljPrviObjekt = new IndividualFictionalSquare (FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max()));

// Debug.Log("sirina 1. fiktivnog temelja IZVAN: " + TemeljPrviObjekt.Width + "  |||||||      duzina 1. fiktivnog temelja: " + TemeljPrviObjekt.Length);


double[] FiktivniTemeljDrugi ={((programState.sirinaB/2)+odabranaTocka[0]),((odabranaTocka[1]-(programState.duzinaL/2)))};
IndividualFictionalSquare TemeljDrugiObjekt = new IndividualFictionalSquare (FiktivniTemeljDrugi.Min(), FiktivniTemeljDrugi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljDrugi.Min(),FiktivniTemeljDrugi.Max()));

// Debug.Log("sirina 2. fiktivnog temelja IZVAN: " + TemeljDrugiObjekt.Width + "  |||||||      duzina 2. fiktivnog temelja: " + TemeljDrugiObjekt.Length);


double[] FiktivniTemeljTreci ={((odabranaTocka[0]-(programState.sirinaB/2))),((programState.duzinaL/2)+odabranaTocka[1])};
IndividualFictionalSquare TemeljTreciObjekt = new IndividualFictionalSquare (FiktivniTemeljTreci.Min(), FiktivniTemeljTreci.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljTreci.Min(),FiktivniTemeljTreci.Max()));

// Debug.Log("sirina 3. fiktivnog temelja IZVAN: " + TemeljTreciObjekt.Width + "  |||||||      duzina 3. fiktivnog temelja: " + TemeljTreciObjekt.Length);


double[] FiktivniTemeljCetvrti ={((odabranaTocka[0]-(programState.sirinaB/2))),(odabranaTocka[1]-(programState.duzinaL/2))};
IndividualFictionalSquare TemeljCetvrtiObjekt = new IndividualFictionalSquare (FiktivniTemeljCetvrti.Min(), FiktivniTemeljCetvrti.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljCetvrti.Min(),FiktivniTemeljCetvrti.Max()));
// Debug.Log("sirina 4. fiktivnog temelja IZVAN: " + TemeljCetvrtiObjekt.Width + "  |||||||      duzina 4. fiktivnog temelja: " + TemeljCetvrtiObjekt.Length);





 if (odabranaTocka[0]>programState.sirinaB/2 && odabranaTocka[1]<=(programState.duzinaL/2)){
dotTypeLocation = 1;
Debug.Log("TOCKA VAN TEMELJA, po X SAMO VANI!!!");

    FiktivniTemeljPrvi = new double[] {((programState.sirinaB/2)+odabranaTocka[0]),( (programState.duzinaL/2)- odabranaTocka[1])};
TemeljPrviObjekt = new IndividualFictionalSquare (FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max()));

// Debug.Log("sirina 1. fiktivnog temelja IZVANx: " + TemeljPrviObjekt.Width + "  |||||||      duzina 1. fiktivnog temelja: " + TemeljPrviObjekt.Length);


 FiktivniTemeljDrugi =new double[] {((programState.sirinaB/2)+odabranaTocka[0]),(programState.duzinaL-((programState.duzinaL/2)- odabranaTocka[1]))};
 TemeljDrugiObjekt = new IndividualFictionalSquare (FiktivniTemeljDrugi.Min(), FiktivniTemeljDrugi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljDrugi.Min(),FiktivniTemeljDrugi.Max()));

// Debug.Log("sirina 2. fiktivnog temelja IZVANx: " + TemeljDrugiObjekt.Width + "  |||||||      duzina 2. fiktivnog temelja: " + TemeljDrugiObjekt.Length);


FiktivniTemeljTreci =new double[] {(odabranaTocka[0]-(programState.sirinaB/2)),( (programState.duzinaL/2)- odabranaTocka[1])};
 TemeljTreciObjekt = new IndividualFictionalSquare (FiktivniTemeljTreci.Min(), FiktivniTemeljTreci.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljTreci.Min(),FiktivniTemeljTreci.Max()));

// Debug.Log("sirina 3. fiktivnog temelja IZVANx: " + TemeljTreciObjekt.Width + "  |||||||      duzina 3. fiktivnog temelja: " + TemeljTreciObjekt.Length);


 FiktivniTemeljCetvrti = new double[]  {(odabranaTocka[0]-(programState.sirinaB/2)),(programState.duzinaL-((programState.duzinaL/2)- odabranaTocka[1]))};
 TemeljCetvrtiObjekt = new IndividualFictionalSquare (FiktivniTemeljCetvrti.Min(), FiktivniTemeljCetvrti.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljCetvrti.Min(),FiktivniTemeljCetvrti.Max()));
// Debug.Log("sirina 4. fiktivnog temelja IZVANx: " + TemeljCetvrtiObjekt.Width + "  |||||||      duzina 4. fiktivnog temelja: " + TemeljCetvrtiObjekt.Length);






}

else if(odabranaTocka[0]<=(programState.sirinaB/2) && odabranaTocka[1]>(programState.duzinaL/2)){
dotTypeLocation = 2;

Debug.Log("TOCKA VAN TEMELJA, po Y SAMO VANI!!!");


    FiktivniTemeljPrvi = new double[] {((programState.sirinaB/2)+odabranaTocka[0]),( (programState.duzinaL)+ (odabranaTocka[1]- (programState.duzinaL/2)))};
TemeljPrviObjekt = new IndividualFictionalSquare (FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljPrvi.Min(),FiktivniTemeljPrvi.Max()));

Debug.Log("sirina 1. fiktivnog temelja IZVANy: " + TemeljPrviObjekt.Width + "  |||||||      duzina 1. fiktivnog temelja: " + TemeljPrviObjekt.Length);


 FiktivniTemeljDrugi =new double[] {(programState.sirinaB-((programState.sirinaB/2)+odabranaTocka[0])),((programState.duzinaL)+ (odabranaTocka[1]- (programState.duzinaL/2)))};
 TemeljDrugiObjekt = new IndividualFictionalSquare (FiktivniTemeljDrugi.Min(), FiktivniTemeljDrugi.Max(), initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljDrugi.Min(),FiktivniTemeljDrugi.Max()));

Debug.Log("sirina 2. fiktivnog temelja IZVANy: " + TemeljDrugiObjekt.Width + "  |||||||      duzina 2. fiktivnog temelja: " + TemeljDrugiObjekt.Length);


FiktivniTemeljTreci =new double[] {((programState.sirinaB/2)+odabranaTocka[0]),( odabranaTocka[1]- (programState.duzinaL/2))};
 TemeljTreciObjekt = new IndividualFictionalSquare (FiktivniTemeljTreci.Min(), FiktivniTemeljTreci.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljTreci.Min(),FiktivniTemeljTreci.Max()));

Debug.Log("sirina 3. fiktivnog temelja IZVANy: " + TemeljTreciObjekt.Width + "  |||||||      duzina 3. fiktivnog temelja: " + TemeljTreciObjekt.Length);


 FiktivniTemeljCetvrti = new double[] {(programState.sirinaB-((programState.sirinaB/2)+odabranaTocka[0])),((odabranaTocka[1]- (programState.duzinaL/2)))};
 TemeljCetvrtiObjekt = new IndividualFictionalSquare (FiktivniTemeljCetvrti.Min(), FiktivniTemeljCetvrti.Max(),initializeSteinbrennerCalculation.CalculateSteinbrenner(FiktivniTemeljCetvrti.Min(),FiktivniTemeljCetvrti.Max()));
Debug.Log("sirina 4. fiktivnog temelja IZVANy: " + TemeljCetvrtiObjekt.Width + "  |||||||      duzina 4. fiktivnog temelja: " + TemeljCetvrtiObjekt.Length);




}



 void AddValue(int type){

 
    for(var i = 0; i < TemeljPrviObjekt.SteinbrennerResult.depthList.Count; i ++){
        double ValueSum = new double () ;
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


if (type==0){
    
     ValueSum = TemeljPrviObjekt.SteinbrennerResult.valueList[i]-TemeljDrugiObjekt.SteinbrennerResult.valueList[i]-TemeljTreciObjekt.SteinbrennerResult.valueList[i]+TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i];
}


else if (type == 1) {

     ValueSum = TemeljPrviObjekt.SteinbrennerResult.valueList[i]+TemeljDrugiObjekt.SteinbrennerResult.valueList[i]-TemeljTreciObjekt.SteinbrennerResult.valueList[i]-TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i];

}

else if (type == 2)
{
     ValueSum = TemeljPrviObjekt.SteinbrennerResult.valueList[i]+TemeljDrugiObjekt.SteinbrennerResult.valueList[i]-TemeljTreciObjekt.SteinbrennerResult.valueList[i]-TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i];

}

SteinBrennerRezultat.valueList.Add(ValueSum);
// Debug.Log(SteinBrennerRezultat.valueList[i] + "VAZNO VAN TEMELJA SUMA");

// Debug.Log(TemeljPrviObjekt.SteinbrennerResult.valueList[i]+ "VAZNO VAN TEMELJ 1");
// Debug.Log(TemeljDrugiObjekt.SteinbrennerResult.valueList[i] + "VAZNO VAN TEMELJ 2");
// Debug.Log(TemeljTreciObjekt.SteinbrennerResult.valueList[i] + "VAZNO VAN TEMELJ 3");
// Debug.Log(TemeljCetvrtiObjekt.SteinbrennerResult.valueList[i] + "VAZNO VAN TEMELJ 4");

    }
}



AddValue(dotTypeLocation);




}



            exportToCsvButton.SetActive(true);

programState.SteinBrennerRezultatOdabraneTocke.depthList = SteinBrennerRezultat.depthList;
programState.SteinBrennerRezultatOdabraneTocke.valueList = SteinBrennerRezultat.valueList;

programState.dodatnaNaprezanja = new List<double>();

for (int i = 0; i <SteinBrennerRezultat.valueList.Count; i++){


programState.dodatnaNaprezanja.Add(SteinBrennerRezultat.valueList[i] * programState.povrsinskoNaprezanje) ;

}


SteinBrennerRezultat.depthList.ForEach(i => 
    {
if (i>konacnaDubina){
    konacnaDubina = (double)i;
// Debug.Log(konacnaDubina+"konacna dubina");
        }
    }
);

programState.dodatnaNaprezanja.ForEach(i => 
    {

// Debug.Log(i + "skoro gotovo");


if (i>najvecaVrijednost){
    najvecaVrijednost = (double)i;
    programState.maxIValue = i;
        }


if ( i< najmanjaVrijednost){

  najmanjaVrijednost = (double)i;

}

    }
);

Vector2 lastCircleGameObjectLocation= new Vector2(-10,-10);
for(var i = 0; i < SteinBrennerRezultat.depthList.Count; i ++){
    
 
float xCoordinate = (float) (programState.dodatnaNaprezanja[i]/najvecaVrijednost)*programState.graphSize[0];
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



 ShowAxisNumbersNGrid();

// Debug.Log(programState.graphSize[1] + "graphSize VAZNO");
// Debug.Log(programState.CanvasSize + "CanvasSize");
      backgroundGraph.SetAsFirstSibling();



    }

private void ShowValueListener (Vector2 anchoredPosition){
    
    if (!valueShown ){ showValue( anchoredPosition);
}
    Debug.Log("gwew");}


    private GameObject CreateCircle(Vector2 anchoredPosition){

        GameObject circleObject = new GameObject ("circle",typeof(Image));
        circleObject.gameObject.tag = "deleteGraphStuff";
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
ValuePanelRectTransform.sizeDelta = new Vector2(programState.graphSize[1]*.25f,programState.graphSize[1]*.25f);

GameObject panelTemplateClone = GameObject.Find("PanelTemplateValue(Clone)");
Transform dubinaText =  panelTemplateClone.transform.Find("TextValueDubina");
Transform naprezanjeText =  panelTemplateClone.transform.Find("TextValueI");


dubinaText.GetComponent<Text>().text = "z:"+(programState.graphSize[1]- anchoredPosition[1]).ToString("0.0");
naprezanjeText.GetComponent<Text>().text = "Δσ:"+((anchoredPosition[0]/programState.graphSize[0])*najvecaVrijednost).ToString("0.00");

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

        else{     
            if ( labelXText>100){

labelX.GetComponent<Text>().text=labelXText.ToString("0");
            }
               else if (labelXText> 10){
labelX.GetComponent<Text>().text=labelXText.ToString("0.0");


               }

               else{
labelX.GetComponent<Text>().text=labelXText.ToString("0.00");


               }
        
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

float najbliziZadnjem = 5000;

for (int i = 0; i<=10; i++){


       float dubina = programState.graphSize[1];
double dubinaDjeljivaSPet = (Math.Ceiling( dubina)+(5-Math.Ceiling(dubina)%5));
RectTransform labelY = Instantiate(labelTemplateY);
   RectTransform gridY = Instantiate(templateGridObject);

 
        labelY.SetParent(graphContainer, false);
        labelY.gameObject.SetActive(true);
      
   gridY.SetParent(graphContainer, false);
   gridY.gameObject.SetActive(true);




    //   float dubina= (float) Math.Ceiling(programState.graphSize[1]+(6-(programState.graphSize[1]%5)));
      double labelYText;
  float labelYYposition ;

  
Debug.Log(dubinaDjeljivaSPet);
if (i!=10){ 
    
if (i*(dubinaDjeljivaSPet/10)<dubina){

    labelYText = i*(dubinaDjeljivaSPet/10);
        labelYYposition = dubina - (float) (i/10f*(dubinaDjeljivaSPet));
najbliziZadnjem = labelYYposition;
      
}


else{
  labelYText = 0;
        labelYYposition = 44* dubina ;
        

}
        }

        else{
      labelYText =  dubina;

      if ( najbliziZadnjem<1){

  labelYYposition =dubina*44 ;

      }
      else{
        labelYYposition = 1/10 * dubina ;
}
        Debug.Log("BLIZINA:"+labelYYposition);
        Debug.Log("BLIZINA:"+najbliziZadnjem);

        }


  

       
        
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
        gameObject.gameObject.tag="deleteGraphStuff";
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


