using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManagerScript : MonoBehaviour
{
    private GameObject[] lights;
    private GameObject ball;

    public Color defaultColor = new Color32(85, 85, 85, 255);
    public Color alternateColor = new Color32(80, 80, 80, 255); 

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");           
    }

    void Update() 
    {
        if (Input.GetKeyUp(KeyCode.R)) {
            foreach (GameObject light in lights) {
                int temp = Random.Range(0, lights.Length);
                alternateColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.cyan;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }    

        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.magenta;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.yellow;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha4)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.red;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }       

        if (Input.GetKeyUp(KeyCode.Alpha5)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.green;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha6)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.blue;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }    

        if (Input.GetKeyUp(KeyCode.Alpha7)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.grey;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }  

        if (Input.GetKeyUp(KeyCode.Alpha8)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.white;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }  

        if (Input.GetKeyUp(KeyCode.Alpha9)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.black;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            }
        }                  
    }

    // Update is called once per frame
    public void LightUp()
    {
        int temp = Random.Range(0, lights.Length);
        alternateColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        StartCoroutine(LightDelay(temp));       
    }

    IEnumerator LightDelay(int temp) {
        yield return new WaitForSeconds (0.5f);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
    }
}
