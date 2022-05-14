using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManagerScript : MonoBehaviour
{
    private GameObject[] lights;
    private GameObject[] leftLights;
    private GameObject[] rightLights;
    private GameObject ball;

    public Color defaultColor = new Color32(85, 85, 85, 255);
    public Color alternateColor = new Color32(80, 80, 80, 255); 

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");   
        leftLights = GameObject.FindGameObjectsWithTag("LeftLight");
        rightLights = GameObject.FindGameObjectsWithTag("RightLight");
        ball = GameObject.FindGameObjectWithTag ("Ball");
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

        if (Input.GetKey(KeyCode.S)) {
            StartCoroutine(StrobeRandom());
        }

        if (Input.GetKey(KeyCode.E)) {
            StartCoroutine(StrobeWhite());
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

    public void LightUp() {
        int temp = Random.Range(0, lights.Length);
        alternateColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        lights[temp].gameObject.GetComponent<LightScript>().isLit = true;       
    }

    public void LightUpAllCyan() {
        foreach (GameObject light in lights) {
            alternateColor = Color.cyan;
            light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        }        
    }      

    public void CheckTable() {
        int amount = 0;

        foreach (GameObject light in lights) {
            if (light.GetComponent<LightScript>().isLit == true)  {
                amount++;
            }
        }

        if (amount >= lights.Length)
        {
            foreach (GameObject light in lights) {
                light.GetComponent<LightScript>().isLit = false;
            }
            LightUpAllCyan();
        }
    }

    public void StrobeFunction() {
        StartCoroutine(StrobeGutter());
    }

    public void RunwayLeftFunction() {
        StartCoroutine(RunwayLeft());
    }  

    public void RunwayRightFunction() {
        StartCoroutine(RunwayRight());
    }

    IEnumerator StrobeRandom() {
        foreach (GameObject light in lights) {
            int temp = Random.Range(0, lights.Length);
            alternateColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            Material m = this.lights[temp].GetComponent<Renderer>().material;
            Color32 c = this.lights[temp].GetComponent<Renderer>().material.color;
            this.lights[temp].GetComponent<Renderer>().material = null;
            this.lights[temp].GetComponent<Renderer>().material.color = alternateColor * Mathf.Pow(2, 2);
            lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
            yield return new WaitForSeconds(0.1f);
            this.lights[temp].GetComponent<Renderer>().material = m;
            this.lights[temp].GetComponent<Renderer>().material.color = c;             
            
            lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        }           
    }  

    IEnumerator StrobeWhite() {
        foreach (GameObject light in lights) {
            int temp = Random.Range(0, lights.Length);
            alternateColor = Color.black;

            Material m = this.lights[temp].GetComponent<Renderer>().material;
            Color32 c = this.lights[temp].GetComponent<Renderer>().material.color;
            this.lights[temp].GetComponent<Renderer>().material = null;
            this.lights[temp].GetComponent<Renderer>().material.color = Color.white * Mathf.Pow(2, 2);
            yield return new WaitForSeconds(0.1f);
            this.lights[temp].GetComponent<Renderer>().material = m;
            this.lights[temp].GetComponent<Renderer>().material.color = c;             
            
            this.lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            this.lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        }           
    }        

    IEnumerator StrobeGutter() {
        foreach (GameObject light in lights) {
            int temp = Random.Range(0, lights.Length);
            alternateColor = Color.black;

            Material m = light.GetComponent<Renderer>().material;
            Color32 c = light.GetComponent<Renderer>().material.color;
            light.GetComponent<Renderer>().material = null;
            light.GetComponent<Renderer>().material.color = Color.white * Mathf.Pow(2, 2);
            yield return new WaitForSeconds(0.1f);
            light.GetComponent<Renderer>().material = m;
            light.GetComponent<Renderer>().material.color = c;             
            
            light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));

            light.gameObject.GetComponent<AudioSource>().Play();
        }   
        
        foreach (GameObject light in lights) {
            light.GetComponent<LightScript>().isLit = false;
        }        
        
        //ball.GetComponent<BallScript>().Spawn();        
    }

    IEnumerator RunwayLeft() {
        foreach (GameObject leftLight in leftLights) {
            int temp = Random.Range(0, leftLights.Length);
            alternateColor = Color.black;

            Material m = leftLight.GetComponent<Renderer>().material;
            Color32 c = leftLight.GetComponent<Renderer>().material.color;
            leftLight.GetComponent<Renderer>().material = null;
            leftLight.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f) * Mathf.Pow(2, 2);
            yield return new WaitForSeconds(0.05f);
            leftLight.GetComponent<Renderer>().material = m;
            leftLight.GetComponent<Renderer>().material.color = c;             
            
            leftLight.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            leftLight.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        }        
    }   

    IEnumerator RunwayRight() {
        foreach (GameObject rightLight in rightLights) {
            int temp = Random.Range(0, rightLights.Length);
            alternateColor = Color.black;

            Material m = rightLight.GetComponent<Renderer>().material;
            Color32 c = rightLight.GetComponent<Renderer>().material.color;
            rightLight.GetComponent<Renderer>().material = null;
            rightLight.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f) * Mathf.Pow(2, 2);
            yield return new WaitForSeconds(0.05f);
            rightLight.GetComponent<Renderer>().material = m;
            rightLight.GetComponent<Renderer>().material.color = c;             
            
            rightLight.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            rightLight.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, 2));
        }        
    }       
}
