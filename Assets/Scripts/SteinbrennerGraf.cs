using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteinbrennerGraf : MonoBehaviour
{
     public Sprite krugSprite;
    private RectTransform graphContainer;

    

    public void InitializeSteinbrennerGraph(){
 
    double konacnaDubina = 0;


    double najvecaVrijednost = 0;
    double najmanjaVrijednost = 50000;

graphContainer = GameObject.Find("GraphContainer").GetComponent<RectTransform>();
GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();
SteinbrennerFormula initializeSteinbrennerCalculation = programManager.GetComponent<SteinbrennerFormula>();
(List<double>depthList, List<double> valueList) SteinBrennerRezultat= initializeSteinbrennerCalculation.CalculateSteinbrenner();



SteinBrennerRezultat.depthList.ForEach(i => 
    {
if (i>konacnaDubina){
    konacnaDubina = (double)i;
Debug.Log(konacnaDubina+"konacna dubina");
        }
    }
);

SteinBrennerRezultat.valueList.ForEach(i => 
    {

Debug.Log(i + "skoro gotovo");


if (i>najvecaVrijednost){
    najvecaVrijednost = (double)i;
        }


if ( i< najmanjaVrijednost){

  najmanjaVrijednost = (double)i;

}

    }
);


for(var i = 0; i < SteinBrennerRezultat.depthList.Count; i ++){
    
 
float xCoordinate = (float) (SteinBrennerRezultat.valueList[i]/najvecaVrijednost)*programState.graphSize[0];
float yCoordinate = (float) (programState.graphSize[1] - (SteinBrennerRezultat.depthList[i]/konacnaDubina)*programState.graphSize[1]);

    CreateCircle(new Vector2 (xCoordinate, yCoordinate));

    
    }
Debug.Log("---******----**-");


Debug.Log(SteinBrennerRezultat.depthList.Count);
Debug.Log(SteinBrennerRezultat.valueList.Count);

Debug.Log("---******----**-");




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
        rectTransform.sizeDelta = new Vector2 (0.4f,0.4f);
     rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
        
    }
}


