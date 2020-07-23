using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickPositionManager : MonoBehaviour
{

    private GameObject programManager;
    private ProgramState programState;

    public InputField koordinataXInputField;
    public InputField koordinataYInputField;


    public void PointerEnter()
    {

    
        BoxCollider meshRendererTemeljCollider = programState.temeljCollider.GetComponent<BoxCollider>();
        meshRendererTemeljCollider.enabled = false;


    }

    public void PointerExit()
    {
        BoxCollider meshRendererTemeljCollider = programState.temeljCollider.GetComponent<BoxCollider>();
        meshRendererTemeljCollider.enabled = true;

    }





    // Start is called before the first frame update
    void Start()
    {
        programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();
    }

    // Update is called once per frame
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

                Debug.Log(clickPosition);
                if (clickPosition != -Vector3.one)
                {
                    koordinataXInputField.text = clickPosition[0].ToString("0.0");
                    koordinataYInputField.text = clickPosition[2].ToString("0.0");


                }


            }
        }

    }




}
