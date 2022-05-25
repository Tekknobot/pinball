using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BumperScript : MonoBehaviour
{
    public int bumperForce = 150;
    private GameObject ball;
    private GameObject[] standUps;
    private GameObject[] bumpers;
    
    public int points;

    AudioSource audioData;

    public GameObject lightingManager;
    public GameObject table;

    public Color defaultColor = new Color32(85, 85, 85, 255);
    public Color alternateColor = new Color32(80, 80, 80, 255); 
    public float intesity = 3;  
 
    void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball");
        standUps = GameObject.FindGameObjectsWithTag("StandUp");
        bumpers = GameObject.FindGameObjectsWithTag("Bumper"); 
        audioData = GetComponent<AudioSource>();  

        BumperLightUpAllBlack();      
    }
 
    public void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Ball") {
            ball.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
            audioData.Play(0);
            SumScore.Add(points);
            lightingManager.GetComponent<LightingManagerScript>().LightUp();
            lightingManager.GetComponent<LightingManagerScript>().CheckStandUp();
            table.GetComponent<AudioManagerScript>().PlayRandomSong();
            StartCoroutine(StrobeWhite(10));
        }
    } 

    public void BumperLightUpAllBlack() {
        alternateColor = Color.black;
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
        this.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));        
    }    

    public void BumperLightUpAllWhite() {
        alternateColor = Color.white;
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
        this.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", alternateColor * Mathf.Pow(2, intesity));        
    }     

    IEnumerator StrobeWhite(float frequency ,float onRatio = 1, float offRatio = 1)
    {
        float cycleDuration = 1.0f / frequency;
        float onDuration = (onRatio/ (onRatio + offRatio)) * cycleDuration;
        float offDuration = (offRatio/ (onRatio + offRatio)) * cycleDuration; 

        for(int i = 0; i < 3; i++) {
            BumperLightUpAllWhite();
            yield return new WaitForSeconds(onDuration);        
            BumperLightUpAllBlack();
            yield return new WaitForSeconds(offDuration);
        }

        BumperLightUpAllBlack();
    } 
}