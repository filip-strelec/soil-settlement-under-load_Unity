using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class DefineStrata : MonoBehaviour
{

    public RectTransform CanvasSlojevi;

    GameObject programManager;
    public GameObject newButton;
    
double maxCurrentLayerDepth;


    ProgramState programState;
     int brojSlojeva ;

public GameObject initialButton;


public void ShowStrata(){


      programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();
if (initialButton.gameObject.activeSelf){
    initialButton.gameObject.SetActive(false);
}
        CanvasSlojevi.gameObject.SetActive(true);

        newButton.gameObject.SetActive(true);
        Debug.Log("test");
programState.initialStart=true;


}
    public void DefineStrataInit()
    { 
        maxCurrentLayerDepth=0;
      programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();
   if  (programState.sirinaB != 0 && programState.duzinaL != 0 && programState.brojSlojeva <= 9)
        {

        CanvasSlojevi.gameObject.SetActive(true);
      
          }
     brojSlojeva  = programState.brojSlojeva;
      
        RectTransform textSloj = CanvasSlojevi.Find("TextSloj").GetComponent<RectTransform>();
        RectTransform textYoungModule = CanvasSlojevi.Find("TextYoungModul").GetComponent<RectTransform>();
        RectTransform inputSloj = CanvasSlojevi.Find("InputFieldSlojDo").GetComponent<RectTransform>();
        RectTransform inputYoungModule = CanvasSlojevi.Find("InputFieldYoungModul").GetComponent<RectTransform>();

int textSlojAnchorOffset = -270;
// int textYoungModuleAnchorOffset = 17;
int inputSlojAnchorOffset = -70;
int inputFieldYoungModuleAnchorOffset = 213;

        // RectTransform labelX = Instantiate();
        

void InitStrataInput(RectTransform element, int offset, int increment, string text, string tag = "noTag"){
  RectTransform textSlojRect = Instantiate(element);
        textSlojRect.SetParent(CanvasSlojevi, false);
        textSlojRect.gameObject.SetActive(true);
        if ( textSlojRect.GetComponent<Text>()){
        textSlojRect.GetComponent<Text>().text=text;}
        textSlojRect.anchoredPosition = new Vector2 (0,0);
 textSlojRect.anchoredPosition= new Vector2(offset,(float)((-120-(increment)*35)));
 textSlojRect.gameObject.tag=tag;
// labelX.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);


}

for (int i = 0; i<brojSlojeva; i++){

   if  (programState.sirinaB != 0 && programState.duzinaL != 0 && programState.brojSlojeva <= 9)
        {



   
// InitStrataInput(textYoungModule, textYoungModuleAnchorOffset, i, "Youngov modul E:", "textStrata"+(i+1));



if (i!=brojSlojeva-1){InitStrataInput( inputSloj, inputSlojAnchorOffset, i, "", "textStrataInput"+(i+1));

  InitStrataInput(textSloj, textSlojAnchorOffset, i, "|"+(i+1)+ ". (m)| 0 -", "textStrata"+(i+1));


}
else{

  InitStrataInput(textSloj, textSlojAnchorOffset, i, "|"+(i+1)+ ". (m)| 0 -"+programState.dubinaZ, "textStrata"+(i+1));


}
InitStrataInput( inputYoungModule, inputFieldYoungModuleAnchorOffset, i, "", "textStrataYoungInput"+(i+1));

      
          }




}

if (GameObject.FindGameObjectWithTag("textStrataInput"+(brojSlojeva))){
GameObject.FindGameObjectWithTag("textStrataInput"+(brojSlojeva)).GetComponent<InputField>().text= programState.dubinaZ.ToString();


}


    }


public void changeDepth(RectTransform CurrentInput){

     programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();


Debug.Log("______");
int clickedStrata =  Int32.Parse( CurrentInput.tag.Substring(CurrentInput.tag.Length-1));
InputField CurrentInputField = CurrentInput.GetComponent<InputField>();
bool canCnovertInput = double.TryParse(CurrentInputField.text, out double inputNumber);


if(inputNumber > programState.dubinaZ){

    inputNumber=programState.dubinaZ;
CurrentInput.GetComponent<InputField>().text =programState.dubinaZ.ToString();
}
maxCurrentLayerDepth = inputNumber;

if(clickedStrata < programState.brojSlojeva-1){
    
GameObject.FindGameObjectWithTag("textStrata"+(clickedStrata+1)).GetComponent<Text>().text="|"+(clickedStrata+1)+". (m)| "+inputNumber.ToString("0.00")+" -";
}


 else {

GameObject.FindGameObjectWithTag("textStrata"+(clickedStrata+1)).GetComponent<Text>().text="|"+(clickedStrata+1)+". (m)| "+inputNumber.ToString("0.00")+" -"+" "+ programState.dubinaZ;


}
}


    public void ConfirmStrata()
    {  programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();
        bool everythingFine = true;
        programState.youngDefined = everythingFine;

     brojSlojeva  = programState.brojSlojeva;

programState.slojeviArray = new double[programState.brojSlojeva];

programState.youngModulArray = new double [programState.brojSlojeva];
for (int i = 0; i<brojSlojeva; i++){

 bool canCnoverSlojevi;


if (i!=brojSlojeva-1){
     canCnoverSlojevi = double.TryParse(GameObject.FindGameObjectWithTag("textStrataInput"+(i+1)).GetComponent<InputField>().text, out double slojevi);

programState.slojeviArray[i] =slojevi;

}

else{
 canCnoverSlojevi = true;
programState.slojeviArray[i] =programState.dubinaZ;


}
 bool canCnoverYoung = double.TryParse( GameObject.FindGameObjectWithTag("textStrataYoungInput"+(i+1)).GetComponent<InputField>().text, out double young);

if (everythingFine){

    everythingFine = canCnoverSlojevi;
    programState.youngDefined = everythingFine;
}

if (everythingFine){

    everythingFine = canCnoverYoung;
    programState.youngDefined = everythingFine;
}

 programState.youngModulArray[i]=young;



}


Debug.Log(programState.slojeviArray.Length);
Debug.Log(programState.youngModulArray.Length);


if (everythingFine ){

CanvasSlojevi.gameObject.SetActive(false);


}





    }


}
