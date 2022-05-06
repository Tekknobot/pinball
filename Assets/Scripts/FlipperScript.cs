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

  void Start() {
    hinge = GetComponent<HingeJoint>();
    audioData = GetComponent<AudioSource>();
  }

  void Update() {
    string key = side == Side.Left ? "left shift" : "right shift";

    if (Input.GetKeyDown(key)) {
      hinge.useMotor = true;
      audioData.Play(0);
    }
    else if (Input.GetKeyUp(key)) {
      hinge.useMotor = false;
      audioData.Play(0);
    }
  }
}
