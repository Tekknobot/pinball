
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightingManagerScript : MonoBehaviour
{
    private GameObject[] lights;
    private GameObject[] leftLights;
    private GameObject[] rightLights;
    private GameObject ball;

    private GameObject[] standUps;

    public Color defaultColor = new Color32(85, 85, 85, 255);
    public Color alternateColor = new Color32(80, 80, 80, 255);

    List<int> list = new List<int>(); 

    public float intesity = 3;
    public int indexCount;

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");   
        leftLights = GameObject.FindGameObjectsWithTag("LeftLight");
        rightLights = GameObject.FindGameObjectsWithTag("RightLight");
        ball = GameObject.FindGameObjectWithTag ("Ball");

        standUps = GameObject.FindGameObjectsWithTag("StandUp");

        PopulateLightList();

        StartCoroutine(StrobeRandom(3));      
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.S)) {
            StartCoroutine(StrobeRandom(10));
        }

        if (Input.GetKey(KeyCode.E)) {
            StartCoroutine(StrobeWhite());
        }                  

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.cyan;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.magenta;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.yellow;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha4)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.red;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        }       

        if (Input.GetKeyUp(KeyCode.Alpha5)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.green;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        } 

        if (Input.GetKeyUp(KeyCode.Alpha6)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.blue;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        }    

        if (Input.GetKeyUp(KeyCode.Alpha7)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.grey;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        }  

        if (Input.GetKeyUp(KeyCode.Alpha8)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.white;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        }  

        if (Input.GetKeyUp(KeyCode.Alpha9)) {
            foreach (GameObject light in lights) {
                alternateColor = Color.black;
                light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
                light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
            }
        }                  
    }

    public void LightUp() {
        if (indexCount >= lights.Length) {
            foreach (GameObject light in lights) {
                light.GetComponent<LightScript>().isLit = false;
            }
            PopulateLightList();
            StartCoroutine(StrobeCyan(10));
            indexCount = 0;
        }
        list.RemoveAt(indexCount);
        alternateColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        lights[indexCount].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
        lights[indexCount].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        lights[indexCount].gameObject.GetComponent<LightScript>().isLit = true;       
        indexCount++;
    }

    public void LightUpAllCyan() {
        foreach (GameObject light in lights) {
            alternateColor = Color.cyan;
            light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        }        
    }

    public void LightUpAllBlack() {
        foreach (GameObject light in lights) {
            alternateColor = Color.black;
            light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        }        
    }    

    public void LightUpAllRandom() {
        foreach (GameObject light in lights) {
            int temp = Random.Range(0, lights.Length);
            alternateColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        }
    }

    public void CheckStandUp() {
        foreach (GameObject standUp in standUps) {
            standUp.GetComponent<StandUpScript>().hasTriggered = false;
        }     
    }

    public void PopulateLightList() {
        for (int n = 0; n < lights.Length; n++)    //  Populate list
        {
            list.Add(n);
        }         
    }

    public void StrobeFunction() {
        StartCoroutine(StrobeGutter());
    }

    IEnumerator StrobeRandom(float frequency ,float onRatio = 1, float offRatio = 1)
    {
        float cycleDuration = 1.0f / frequency;
        float onDuration = (onRatio/ (onRatio + offRatio)) * cycleDuration;
        float offDuration = (offRatio/ (onRatio + offRatio)) * cycleDuration; 

        for(int i = 0; i < 10; i++) {
            LightUpAllRandom();
            yield return new WaitForSeconds(onDuration);        
            LightUpAllBlack();
            yield return new WaitForSeconds(offDuration);
        }

        LightUpAllBlack();
        StartCoroutine(RunwayLeft());
        StartCoroutine(RunwayRight());        
        indexCount = 0;
    } 

    IEnumerator StrobeCyan(float frequency ,float onRatio = 1, float offRatio = 1)
    {
        float cycleDuration = 1.0f / frequency;
        float onDuration = (onRatio/ (onRatio + offRatio)) * cycleDuration;
        float offDuration = (offRatio/ (onRatio + offRatio)) * cycleDuration; 

        for(int i = 0; i < 10; i++) {
            LightUpAllCyan();
            yield return new WaitForSeconds(onDuration);        
            LightUpAllBlack();
            yield return new WaitForSeconds(offDuration);
        }

        LightUpAllCyan();
        indexCount = 0;
    } 

    IEnumerator StrobeWhite() {
        foreach (GameObject light in lights) {
            int temp = Random.Range(0, lights.Length);
            alternateColor = Color.black;

            Material m = this.lights[temp].GetComponent<Renderer>().material;
            Color32 c = this.lights[temp].GetComponent<Renderer>().material.color;
            this.lights[temp].GetComponent<Renderer>().material = null;
            this.lights[temp].GetComponent<Renderer>().material.color = Color.white * Mathf.Pow(2, intesity);
            yield return new WaitForSeconds(0.1f);
            this.lights[temp].GetComponent<Renderer>().material = m;
            this.lights[temp].GetComponent<Renderer>().material.color = c;             
            
            this.lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            this.lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        }           
    }        

    IEnumerator StrobeGutter() {
        foreach (GameObject light in lights) {
            int temp = Random.Range(0, lights.Length);
            alternateColor = Color.black;

            Material m = light.GetComponent<Renderer>().material;
            Color32 c = light.GetComponent<Renderer>().material.color;
            light.GetComponent<Renderer>().material = null;
            light.GetComponent<Renderer>().material.color = Color.white * Mathf.Pow(2, intesity);
            yield return new WaitForSeconds(0.1f);
            light.GetComponent<Renderer>().material = m;
            light.GetComponent<Renderer>().material.color = c;             
            
            light.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            light.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));

            light.gameObject.GetComponent<AudioSource>().Play();
        }   
        
        foreach (GameObject light in lights) {
            light.GetComponent<LightScript>().isLit = false;
        }        
        
        CheckStandUp();  
        PopulateLightList();
        indexCount = 0;     
    }

    IEnumerator RunwayLeft() {
        foreach (GameObject leftLight in leftLights) {
            int temp = Random.Range(0, leftLights.Length);
            alternateColor = Color.black;
            leftLight.GetComponent<Renderer>().material = null;
            leftLight.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f) * Mathf.Pow(2, intesity);
            yield return new WaitForSeconds(0.05f);                        
            leftLight.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            leftLight.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        }    
        StartCoroutine(RunwayLeft());    
    }   

    IEnumerator RunwayRight() {
        foreach (GameObject rightLight in rightLights) {
            int temp = Random.Range(0, rightLights.Length);
            alternateColor = Color.black;
            rightLight.GetComponent<Renderer>().material = null;
            rightLight.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f) * Mathf.Pow(2, intesity);
            yield return new WaitForSeconds(0.05f);                       
            rightLight.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            rightLight.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));
        }    
        StartCoroutine(RunwayRight());    
    }       
}
