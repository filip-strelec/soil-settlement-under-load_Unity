using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramState : MonoBehaviour
{

// Definiranje parametara zadatka
   public double sirinaB;
   public double duzinaL;
   public double dubinaZ;

   public double sirinaKoordSustavaB;

   public double duzinaKoordSustavaL;

   public double maxIValue;

   public double inkrementMjerenjaZ =0.5f;
   public Vector2 graphSize ;
   public Vector2 CanvasSize;
    public bool kameraOnTlocrt = false;

    public GameObject temeljCollider;

    public bool parametersDefined = false;

    
      public Sprite krugSprite;
    public RectTransform axisContainer;


public (List<double>depthList, List<double> valueList) SteinBrennerRezultatOdabraneTocke;

    public double[] koordinateIzracuna =  new double[2];

      public void deleteCircles (){

 GameObject[] oldCircles = GameObject.FindGameObjectsWithTag("tlocrtTocka");
   foreach(GameObject circle in oldCircles){
   GameObject.Destroy(circle);
    Debug.Log("CLEAR"+ circle);}

       }

public  void clearGraph (){

 GameObject[] oldGraph = GameObject.FindGameObjectsWithTag("deleteGraphStuff");

 foreach(GameObject content in oldGraph){
   GameObject.Destroy(content);
      Debug.Log("graph cleared");
}



}


public void createCircles (){

 
 GameObject circleObjectSecond = new GameObject ("circleTocka",typeof(Image));

        circleObjectSecond.transform.SetParent(axisContainer, false);
        circleObjectSecond.GetComponent<Image>().sprite = krugSprite;
        RectTransform rectTransformCircleSecond = circleObjectSecond.GetComponent<RectTransform>();
        circleObjectSecond.GetComponent<Image>().color = new Color(0,255,0, 1f);
        circleObjectSecond.gameObject.tag="tlocrtTocka";
        
  rectTransformCircleSecond.anchorMin = new Vector2 (0.5f,0.5f);
        rectTransformCircleSecond.sizeDelta = new Vector2 ((float)(duzinaL*0.03),(float)(duzinaL*0.03));
     rectTransformCircleSecond.anchorMax = new Vector2(0.5f, 0.5f);
rectTransformCircleSecond.anchoredPosition = new Vector2 ((float)-koordinateIzracuna[0],(float)koordinateIzracuna[1]);



 GameObject circleObjectThird = new GameObject ("circleTocka",typeof(Image));

        circleObjectThird.transform.SetParent(axisContainer, false);
        circleObjectThird.GetComponent<Image>().sprite = krugSprite;
        RectTransform rectTransformCircleThird = circleObjectThird.GetComponent<RectTransform>();
        circleObjectThird.GetComponent<Image>().color = new Color(0,255,0, 1f);
        circleObjectThird.gameObject.tag="tlocrtTocka";
        
  rectTransformCircleThird.anchorMin = new Vector2 (0.5f,0.5f);
        rectTransformCircleThird.sizeDelta = new Vector2 ((float)(duzinaL*0.03),(float)(duzinaL*0.03));
     rectTransformCircleThird.anchorMax = new Vector2(0.5f, 0.5f);
rectTransformCircleThird.anchoredPosition = new Vector2 ((float)koordinateIzracuna[0],(float)-koordinateIzracuna[1]);


 GameObject circleObjectFourth = new GameObject ("circleTocka",typeof(Image));

        circleObjectFourth.transform.SetParent(axisContainer, false);
        circleObjectFourth.GetComponent<Image>().sprite = krugSprite;
        RectTransform rectTransformCircleFourth = circleObjectFourth.GetComponent<RectTransform>();
        circleObjectFourth.GetComponent<Image>().color = new Color(0,255,0, 1f);
        circleObjectFourth.gameObject.tag="tlocrtTocka";
        
  rectTransformCircleFourth.anchorMin = new Vector2 (0.5f,0.5f);
        rectTransformCircleFourth.sizeDelta = new Vector2 ((float)(duzinaL*0.03),(float)(duzinaL*0.03));
     rectTransformCircleFourth.anchorMax = new Vector2(0.5f, 0.5f);
rectTransformCircleFourth.anchoredPosition = new Vector2 ((float)-koordinateIzracuna[0],(float)-koordinateIzracuna[1]);


GameObject circleObject = new GameObject ("circleTockaOriginal",typeof(Image));

        circleObject.transform.SetParent(axisContainer, false);
        circleObject.GetComponent<Image>().sprite = krugSprite;
        RectTransform rectTransformCircle = circleObject.GetComponent<RectTransform>();
        circleObject.GetComponent<Image>().color = new Color(255,0,0, 1f);
        circleObject.gameObject.tag="tlocrtTocka";
        
  rectTransformCircle.anchorMin = new Vector2 (0.5f,0.5f);
        rectTransformCircle.sizeDelta = new Vector2 ((float)(duzinaL*0.03),(float)(duzinaL*0.03));
     rectTransformCircle.anchorMax = new Vector2(0.5f, 0.5f);
rectTransformCircle.anchoredPosition = new Vector2 ((float)koordinateIzracuna[0],(float)koordinateIzracuna[1]);



}






   
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }


   public void RestartProgram(){
Debug.Log("testiram");

   }
}
