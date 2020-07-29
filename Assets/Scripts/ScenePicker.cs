using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour
{
    // Start is called before the first frame update
   public void ScenePickerFunction(string sceneName){
         SceneManager.LoadScene(sceneName); 


   }

   public void ApplicationQuit (){

       Application.Quit();
       Debug.Log("test");
   }
}
