using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickPositionManager : MonoBehaviour
{
    private GameObject programManager;
    private ProgramState programState;

    public InputField koordinataXInputField;
    public InputField koordinataYInputField;
      public Sprite krugSprite;
    public RectTransform axisContainer;

    public bool definedDotByClick;


    public void PointerEnter()
    {

    
        BoxCollider meshRendererTemeljCollider = programState.temeljCollider.GetComponent<BoxCollider>();
        meshRendererTemeljCollider.enabled = false;
definedDotByClick=false;
        // Debug.Log(programState.koordinateIzracuna[0]);
        //         Debug.Log(programState.koordinateIzracuna[1]);



    }

    public void PointerExit()
    {
        BoxCollider meshRendererTemeljCollider = programState.temeljCollider.GetComponent<BoxCollider>();
        meshRendererTemeljCollider.enabled = true;
        definedDotByClick=true;

        // Debug.Log(programState.koordinateIzracuna[0]+"___:___"+programState.koordinateIzracuna[1]);

    }



    // Start is called before the first frame update
    void Start()
    {
        definedDotByClick=true;
        programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();
    }

    // Update is called once per frame


public void changeXCoordinate(){



 bool canConvertKoordinataX = double.TryParse(koordinataXInputField.text, out double koordinataXIzracuna);
  bool canConvertKoordinataY = double.TryParse(koordinataYInputField.text, out double koordinataYIzracuna);

        programState.koordinateIzracuna[0]  = koordinataXIzracuna;
        programState.koordinateIzracuna[1]  = koordinataYIzracuna;
        programState.deleteCircles();
        programState.createCircles();


}

public void changeYCoordinate(){



 bool canConvertKoordinataX = double.TryParse(koordinataXInputField.text, out double koordinataXIzracuna);
  bool canConvertKoordinataY = double.TryParse(koordinataYInputField.text, out double koordinataYIzracuna);

        programState.koordinateIzracuna[0]  = koordinataXIzracuna;
        programState.koordinateIzracuna[1]  = koordinataYIzracuna;

        programState.deleteCircles();
        programState.createCircles();


}


public void characteristicDot(){





        programState.koordinateIzracuna[0]  = programState.sirinaB*0.37;
        programState.koordinateIzracuna[1]  = programState.duzinaL*0.37;

        Debug.Log(programState.koordinateIzracuna[0] +" "+programState.koordinateIzracuna[1] );

        koordinataXInputField.text = (programState.sirinaB*0.37).ToString("0.00");
        koordinataYInputField.text = (programState.duzinaL*0.37).ToString("0.00");



                    programState.koordinateIzracuna[0]= programState.sirinaB*0.37;
                    programState.koordinateIzracuna[1]=programState.duzinaL*0.37;


        programState.deleteCircles();
        programState.createCircles();


}



    void Update()
    {
        if (programState.kameraOnTlocrt == true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector3 clickPosition = -Vector3.one;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;



                if (Physics.Raycast(ray, out hit))
                {

                    clickPosition = hit.point;
                }

                // Debug.Log(clickPosition);
                if (clickPosition != -Vector3.one)
                {
                    koordinataXInputField.text = clickPosition[0].ToString("0.00");
                    koordinataYInputField.text = clickPosition[2].ToString("0.00");

                    programState.koordinateIzracuna[0]= clickPosition[0];
                    programState.koordinateIzracuna[1]=clickPosition[2];
 programState.deleteCircles();
programState.createCircles();
definedDotByClick=true;


                }


            }
        }

    }




}
