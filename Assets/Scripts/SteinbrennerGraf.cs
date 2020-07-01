using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class SteinbrennerGraf : MonoBehaviour
{
     public Sprite krugSprite;
    private RectTransform graphContainer;

    private float SirinaLinije;
    public void InitializeSteinbrennerGraph(){
 
    double konacnaDubina = 0;


    double najvecaVrijednost = 0;
    double najmanjaVrijednost = 50000;

graphContainer = GameObject.Find("GraphContainer").GetComponent<RectTransform>();
GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();

SirinaLinije = (float) (programState.dubinaZ*0.005);
SteinbrennerFormula initializeSteinbrennerCalculation = programManager.GetComponent<SteinbrennerFormula>();
(List<double>depthList, List<double> valueList) SteinBrennerRezultat= initializeSteinbrennerCalculation.CalculateSteinbrenner();



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



  GameObject circleGameObject =  CreateCircle(new Vector2 (xCoordinate, yCoordinate));
  Vector2 circleGameObjectLocation = new Vector2(xCoordinate,yCoordinate);

  if (lastCircleGameObjectLocation[0] !=-10){


   CreateDotConnection(lastCircleGameObjectLocation, circleGameObjectLocation);
Debug.Log("JAKO VAZNO:"+lastCircleGameObjectLocation);
  }
lastCircleGameObjectLocation = circleGameObjectLocation;
    
    }
// Debug.Log("---******----**-");


// Debug.Log(SteinBrennerRezultat.depthList.Count);
// Debug.Log(SteinBrennerRezultat.valueList.Count);

// Debug.Log("---******----**-");




Debug.Log(programState.graphSize[1] + "graphSize VAZNO");
Debug.Log(programState.CanvasSize + "CanvasSize");


    }

    private GameObject CreateCircle(Vector2 anchoredPosition){

        GameObject circleObject = new GameObject ("circle",typeof(Image));
        circleObject.transform.SetParent(graphContainer, false);
        circleObject.GetComponent<Image>().sprite = krugSprite;
        RectTransform rectTransform = circleObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.anchorMin = new Vector2 (0,0);
        rectTransform.sizeDelta = new Vector2 ((float)(SirinaLinije+0.5*SirinaLinije),(float)(SirinaLinije+0.5*SirinaLinije));
     rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
        
    }


public static float GetAngleFromVectorFloat(Vector3 dir) {



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
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, (float)(SirinaLinije));
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
        

        // Debug.Log(dotPositionA+ "positiondotA");
        // Debug.Log(dotPositionB+ "positionDotB");

        // Debug.Log(gameObject+ "gameObject");

        // Debug.Log(rectTransform+ "rectTransform");
        // Debug.Log(dir+ "dir");
        // Debug.Log(distance+ "distance");
     
    }
}


