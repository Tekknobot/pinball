using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side {
  Left,
  Right,
}

public class FlipperScript : MonoBehaviour {
  public Side side;

  HingeJoint hinge;

  AudioSource audioData;

  public GameObject lightingManager;

  void Start() {
    hinge = GetComponent<HingeJoint>();
    audioData = GetComponent<AudioSource>();

    lightingManager.GetComponent<LightingManagerScript>().RunwayLeftFunction();
    lightingManager.GetComponent<LightingManagerScript>().RunwayRightFunction();
  }

  void Update() {
    string key = side == Side.Left ? "left shift" : "right shift";

    if (Input.GetKeyDown(key)) {
      hinge.useMotor = true;
      audioData.Play(0);
      if (key == "left shift") {
        lightingManager.GetComponent<LightingManagerScript>().RunwayLeftFunction();        
      }
      if (key == "right shift") {
        lightingManager.GetComponent<LightingManagerScript>().RunwayRightFunction();
      }      
    }
    else if (Input.GetKeyUp(key)) {
      hinge.useMotor = false;
      audioData.Play(0); 
    }
  }
}
