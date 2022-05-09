using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BumperScript : MonoBehaviour
{
    public int bumperForce = 800;
    private GameObject ball;

    public int points;

    AudioSource audioData;

    public GameObject lightingManager;
 
    void Start () {
        ball = GameObject.FindGameObjectWithTag ("Ball");
        audioData = GetComponent<AudioSource>();        
    }
 
    public void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject == ball) {
            ball.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
            audioData.Play(0);
            SumScore.Add(points);
            lightingManager.GetComponent<LightingManagerScript>().LightUp();
        }
    }    
}