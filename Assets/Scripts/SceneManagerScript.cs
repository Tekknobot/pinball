using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            SceneManager.LoadScene(0);
        } 

        if(Input.GetKeyDown(KeyCode.B)){
            SceneManager.LoadScene(1);
        }      

        if(Input.GetKeyDown(KeyCode.C)){
            SceneManager.LoadScene(2);
        }                      
    }
}
