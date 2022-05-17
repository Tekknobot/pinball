using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpScript : MonoBehaviour {
    public float moveSpeed = 0.01f;
    public bool hasTriggered = false;

    Vector3 upPosition;
    Vector3 downPosition;

    AudioSource audioData;

    public Material cyanMech;
    public Material magentaMech;
    public GameObject textureObject;    

    public GameObject lightingManager;

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
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 2) {
            textureObject.GetComponent<Renderer>().material = cyanMech;
        }

        if (lightingManager.GetComponent<LightingManagerScript>().colorLevel == 3) {
            textureObject.GetComponent<Renderer>().material = magentaMech;
        }        
    }

    public void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.tag == "Ball") {
            hasTriggered = true;
            audioData.Play(0);
            lightingManager.GetComponent<LightingManagerScript>().LightUp();
        }
    }
}