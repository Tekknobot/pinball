using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpScript : MonoBehaviour {
    public float moveSpeed = 0.01f;
    public bool hasTriggered = false;

    Vector3 upPosition;
    Vector3 downPosition;

    AudioSource audioData;

    public GameObject lightingManager;

    void Start() {
        upPosition = transform.position;
        downPosition = transform.position + Vector3.down * transform.localScale.y;
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
    }

    public void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.tag == "Ball") {
            hasTriggered = true;
            audioData.Play(0);
            lightingManager.GetComponent<LightingManagerScript>().LightUp();
        }
    }
}