using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed;
    
        ProgramState programState ;

    // Update is called once per frame

      void Start() {
           GameObject programManager = GameObject.Find("ProgramManager");

           programState = programManager.GetComponent<ProgramState>();
// panSpeed = (float)(programState.dubinaZ*100);


    }
    void Update()
    {
        Debug.Log(panSpeed);
panSpeed = (float)(programState.dubinaZ*2);

Vector3 cameraPosition = transform.position;



if(Input.GetKey("a")){

cameraPosition.x -= panSpeed * Time.deltaTime;

}
if(Input.GetKey("d")){

cameraPosition.x += panSpeed * Time.deltaTime;

}

if (programState.kameraOnTlocrt){

if(Input.GetKey("w")){

cameraPosition.z += panSpeed * Time.deltaTime;

}

if(Input.GetKey("s")){

cameraPosition.z -= panSpeed * Time.deltaTime;

}

if(Input.GetKey("q")){

cameraPosition.y += panSpeed * Time.deltaTime;

}

if(Input.GetKey("e")){

cameraPosition.y -= panSpeed * Time.deltaTime;

}




}

else{



if(Input.GetKey("w")){

cameraPosition.y += panSpeed * Time.deltaTime;

}

if(Input.GetKey("s")){

cameraPosition.y -= panSpeed * Time.deltaTime;

}

if(Input.GetKey("q")){

cameraPosition.z -= panSpeed * Time.deltaTime;

}

if(Input.GetKey("e")){

cameraPosition.z += panSpeed * Time.deltaTime;

}


}


//reset Scene

     if (Input.GetKeyDown("r")) { 
         SceneManager.LoadScene("OneRectangularLoad"); 
     }






transform.position = cameraPosition;

    }
}
