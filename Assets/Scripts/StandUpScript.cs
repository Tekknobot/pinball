using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpScript : MonoBehaviour {
    public float moveSpeed = 0.01f;
    public bool hasTriggered = false;

    Vector3 upPosition;
    Vector3 downPosition;

    AudioSource audioData;

    public Material blackMech;
    public Material cyanMech;
    public Material magentaMech;
    public Material yellowMech;
    public Material redMech;
    public Material greenMech;
    public Material blueMech;

    public GameObject textureObject;    

    public GameObject lightingManager;
    public GameObject explosion;

    void Start() {
        upPosition = transform.position;
        downPosition = transform.position + Vector3.down * (transform.localScale.y+0.03f);
        audioData = GetComponent<AudioSource>(); 

        lightingManager = GameObject.FindGameObjectWithTag("LightingManager");
    }

    void Update() {
        if (hasTriggered && transform.position != downPosition) {
            transform.position += Vector3.down
                * Mathf.Min(moveSpeed, Vector3.Distance(transform.position, downPosition));
        }
        else if (!hasTriggered && transform.position != upPosition){
            transform.position += Vector3.up
                * Mathf.Min(moveSpeed, Vector3.Distance(transform.position, upPosition));
            
            GetComponent<BoxCollider>().enabled = true;
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 1) {
            textureObject.GetComponent<Renderer>().material = blackMech;
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 2) {
            textureObject.GetComponent<Renderer>().material = cyanMech;
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 3) {
            textureObject.GetComponent<Renderer>().material = magentaMech;
        }      

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 4) {
            textureObject.GetComponent<Renderer>().material = yellowMech;
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 5) {
            textureObject.GetComponent<Renderer>().material = redMech;
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 6) {
            textureObject.GetComponent<Renderer>().material = blueMech;
        }      

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 7) {
            textureObject.GetComponent<Renderer>().material = greenMech;
        }   

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel >= 8) {
            textureObject.GetComponent<Renderer>().material = blackMech;
        }                          
    }

    public void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.tag == "Ball") {
            hasTriggered = true;
            audioData.Play(0);
            lightingManager.GetComponent<LightingManagerScript>().LightUp();
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            GetComponent<BoxCollider>().enabled = false;
            SumScore.Add(50);
        }
    }
}