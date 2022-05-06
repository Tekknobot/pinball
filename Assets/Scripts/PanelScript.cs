using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PanelScript : MonoBehaviour
{
    private GameObject[] panels;
    private GameObject ball;

    public Color defaultColor = new Color32(85, 85, 85, 255);
    public Color alternateColor = new Color32(80, 80, 80, 255);     
 
    void Start () {
        panels = GameObject.FindGameObjectsWithTag("Panel");  
        ball = GameObject.FindGameObjectWithTag ("Ball");     
    }
 
    public void OnTriggerEnter (Collider collider)
    {
        foreach (GameObject panel in panels) {
            if (collider.gameObject == ball) {
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", alternateColor);
            }
        }
    } 

    public void OnTriggerExit (Collider collider)
    {
        foreach (GameObject panel in panels) {
            if (collider.gameObject == ball) {
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", defaultColor);
            }
        }
    } 
}