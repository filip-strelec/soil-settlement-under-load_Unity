using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 420f;
    

    // Update is called once per frame

      void Start() {
           GameObject programManager = GameObject.Find("ProgramManager");
        ProgramState programState = programManager.GetComponent<ProgramState>();



    }
    void Update()
    {
        

Vector3 cameraPosition = transform.position;

if(Input.GetKey("w")){

cameraPosition.y += panSpeed * Time.deltaTime;

}

if(Input.GetKey("s")){

cameraPosition.y -= panSpeed * Time.deltaTime;

}


if(Input.GetKey("a")){

cameraPosition.x -= panSpeed * Time.deltaTime;

}
if(Input.GetKey("d")){

cameraPosition.x += panSpeed * Time.deltaTime;

}

if(Input.GetKey("q")){

cameraPosition.z -= panSpeed * Time.deltaTime;

}

if(Input.GetKey("e")){

cameraPosition.z += panSpeed * Time.deltaTime;

}






transform.position = cameraPosition;

    }
}
