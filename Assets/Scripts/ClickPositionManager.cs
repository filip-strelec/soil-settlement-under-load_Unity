using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
if ( Input.GetMouseButtonDown (0)){

Vector3 clickPosition = -Vector3.one;

Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition);
RaycastHit hit ; 


if ( Physics.Raycast(ray, out hit)){

    clickPosition = hit.point;
}

Debug.Log(clickPosition);

}

    }
}
