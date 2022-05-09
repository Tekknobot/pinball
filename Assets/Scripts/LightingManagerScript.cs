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

    // Update is called once per frame
    public void LightUp()
    {
        int temp = Random.Range(0, lights.Length);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        StartCoroutine(LightDelay(temp));       
    }

    IEnumerator LightDelay(int temp) {
        yield return new WaitForSeconds (0.5f);
        lights[temp].gameObject.GetComponent<Renderer>().material.SetColor("_Color", defaultColor);
    }
}
