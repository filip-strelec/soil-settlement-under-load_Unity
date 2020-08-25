using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class SteinbrennerGrafDeformacije : MonoBehaviour
{
     public Sprite krugSprite;
    public RectTransform graphContainer;

    private float SirinaLinije;

    private RectTransform labelTemplateX;

    private RectTransform labelTemplateY;

    public RectTransform templateGridObject;

    public RectTransform PanelTemplateValue;

    public RectTransform backgroundGraph;


private RectTransform xAxisLabel;
private RectTransform yAxisLabel;
private RectTransform graphTitle;


 private bool valueShown = false;
    
   private double konacnaDubina = 0;
   


  private  double najvecaVrijednost = 0;
    private double najmanjaVrijednost = 50000;


 

   public void InitializeSteinbrennerGraph(){





    konacnaDubina = 0;


    najvecaVrijednost = -5000000000000;
    najmanjaVrijednost = 5000000000000;


GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();
// programState.clearGraph();




SirinaLinije = (float) (programState.dubinaZ*0.005);



programState.SteinBrennerRezultatOdabraneTocke.depthList.ForEach(i => 
    {
if (i>konacnaDubina){
    konacnaDubina = (double)i;
// Debug.Log(konacnaDubina+"konacna dubina");
        }
    }
);

programState.relativneDeformacije.ForEach(i => 
    {

// Debug.Log(i + "skoro gotovo");


// NEEDS refactoring badly

if (i>najvecaVrijednost){
      

    if (i<0.00001){

najvecaVrijednost = 0.00001;
programState.maxIValue = 0.00001;

    }
     else   if (i<0.00003){

najvecaVrijednost = 0.00003;
programState.maxIValue = 0.00003;

    }
        else   if (i<0.00005){

najvecaVrijednost = 0.00005;
programState.maxIValue = 0.00005;

    }

    else   if (i<0.00008){

najvecaVrijednost = 0.00008;
programState.maxIValue = 0.00008;

    }




  else  if (i<0.0001){

najvecaVrijednost = 0.0001;
programState.maxIValue = 0.0001;

    }


  else   if (i<0.00025){

najvecaVrijednost = 0.00025;
programState.maxIValue = 0.00025;

    }

    
  else   if (i<0.0005){

najvecaVrijednost = 0.0005;
programState.maxIValue = 0.0005;

    }



  else   if (i<0.00075){

najvecaVrijednost = 0.00075;
programState.maxIValue = 0.00075;

    }


  else   if (i<0.001){

najvecaVrijednost = 0.001;
programState.maxIValue = 0.001;

    }


  else   if (i<0.0025){

najvecaVrijednost = 0.0025;
programState.maxIValue = 0.0025;

    }

    
  else   if (i<0.005){

najvecaVrijednost = 0.005;
programState.maxIValue = 0.005;

    }



  else   if (i<0.0075){

najvecaVrijednost = 0.0075;
programState.maxIValue = 0.0075;

    }


    else   if (i<0.01){

najvecaVrijednost = 0.01;
programState.maxIValue = 0.01;

    }


   
  else   if (i<0.025){

najvecaVrijednost = 0.025;
programState.maxIValue = 0.025;

    }

    
  else   if (i<0.05){

najvecaVrijednost = 0.05;
programState.maxIValue = 0.05;

    }



  else   if (i<0.075){

najvecaVrijednost = 0.075;
programState.maxIValue = 0.075;

    }

    
   else if (i<0.1){

najvecaVrijednost = 0.1;
programState.maxIValue = 0.1;

    }

    else if (i<0.25){
najvecaVrijednost = 0.25;
programState.maxIValue = 0.25;

    }

        else if (i<0.50){
najvecaVrijednost = 0.50;
programState.maxIValue = 0.50;

    }


    else{
    najvecaVrijednost = (double)Math.Ceiling(i);
    programState.maxIValue = Math.Ceiling(i);
}
        }


if ( i< najmanjaVrijednost){

  najmanjaVrijednost = (double)i;

}

    }
);

Vector2 lastCircleGameObjectLocation= new Vector2(-10,-10);
for(var i = 0; i < programState.SteinBrennerRezultatOdabraneTocke.depthList.Count; i ++){
    
 
float xCoordinate = (float) (programState.relativneDeformacije[i]/najvecaVrijednost)*programState.graphSize[0];
float yCoordinate = (float) (programState.graphSize[1] - (programState.SteinBrennerRezultatOdabraneTocke.depthList[i]/konacnaDubina)*programState.graphSize[1]);

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
//redundant use (needs refactoring)
private void hidePanel (){


    GameObject panelTemplateClone = GameObject.Find("PanelTemplateValueDeformation(Clone)");

    Destroy (panelTemplateClone);
    valueShown= false;


}

//redundant use (needs refactoring)
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
ValuePanelRectTransform.sizeDelta = new Vector2(programState.graphSize[1]*.35f,programState.graphSize[1]*.35f);

GameObject panelTemplateClone = GameObject.Find("PanelTemplateValueDeformation(Clone)");
Transform dubinaText =  panelTemplateClone.transform.Find("TextValueDubina");
Transform naprezanjeText =  panelTemplateClone.transform.Find("TextValueI");


dubinaText.GetComponent<Text>().text = "z(m):"+(programState.graphSize[1]- anchoredPosition[1]).ToString("0.0");
naprezanjeText.GetComponent<Text>().text = "ε(%):"+((anchoredPosition[0]/programState.graphSize[0])*najvecaVrijednost).ToString("0.00000");

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

        labelTemplateX = graphContainer.Find("TextLabelTemplateXDeformation").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("TextLabelTemplateYDeformation").GetComponent<RectTransform>();

        //Dobiveno curve fit metodom
double labelsScale =0.02643327*programState.graphSize[1] - 0.04642976;
  if (labelsScale < 0.05){
    labelsScale =0.05;
}


xAxisLabel = Instantiate( graphContainer.Find("XAxisLabelDeformation").GetComponent<RectTransform>());
xAxisLabel.SetParent(graphContainer, false);
   xAxisLabel.gameObject.SetActive(true);

xAxisLabel.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);



yAxisLabel = Instantiate( graphContainer.Find("YAxisLabelDeformation").GetComponent<RectTransform>());
yAxisLabel.SetParent(graphContainer, false);
   yAxisLabel.gameObject.SetActive(true);
yAxisLabel.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);


graphTitle = Instantiate( graphContainer.Find("GraphTitle").GetComponent<RectTransform>());
graphTitle.SetParent(graphContainer, false);
   graphTitle.gameObject.SetActive(true);
graphTitle.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);
graphTitle.anchoredPosition = new Vector2 (0, (float) (5.5*labelsScale));

   
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
   
 if (i==5){
     labelX.GetComponent<Text>().text=labelXText.ToString("0.00000");

 }
         else{     labelX.GetComponent<Text>().text=labelXText.ToString("0.000");}     

    
}
        float labelXXposition = (i/5f*programState.graphSize[0]);
        
        // Debug.Log(programState.graphSize[1] + "graphSize ______________YYY VAZNO");
        // Debug.Log(programState.graphSize[0] + "graphSize ______XXXXVAZNO");

 labelX.anchoredPosition= new Vector2(labelXXposition,(float)(programState.graphSize[1]+(2.3*labelsScale)));
labelX.localScale=new Vector2 ((float)(0.8*labelsScale), (float)(0.8*labelsScale));

gridX.anchoredPosition = new Vector2(labelXXposition,(programState.graphSize[1]/2));
gridX.localScale =new Vector2((float)(labelsScale/4), programState.graphSize[1]);
gridX.SetAsFirstSibling();
}

float najbliziZadnjem = 0;

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
  
// Debug.Log(dubinaDjeljivaSPet);
if (i!=10){ 
    
if (i*(dubinaDjeljivaSPet/10)<dubina){

    labelYText = i*(dubinaDjeljivaSPet/10);
        labelYYposition = dubina - (float) (i/10f*(dubinaDjeljivaSPet));
             if (labelYYposition>najbliziZadnjem && labelYYposition<3){
najbliziZadnjem = labelYYposition;
      }
      
}


else{
  labelYText = 0;
        labelYYposition = 44* dubina ;
        

}
        }

            else{
      labelYText =  dubina;

      if ( najbliziZadnjem<2){

  labelYYposition =dubina*44 ;

      }
      else{
        labelYYposition = 1/10 * dubina ;
}
 

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
gridY.localScale =new Vector2(programState.graphSize[0],(float)labelsScale/4);
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


