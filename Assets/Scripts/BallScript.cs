using UnityEngine;

public class BallScript : MonoBehaviour {
  Vector3 initialPosition;
  public GameObject wall;
  public GameObject lightingManager;

  void Start() {
    initialPosition = transform.position;
  }

  void Update() {
    if (Input.GetKeyUp("escape")) {
      transform.position = initialPosition;
    }
  }

  public void OnTriggerEnter (Collider collider)
  {
    if (collider.gameObject == wall) {
      lightingManager.GetComponent<LightingManagerScript>().StrobeFunction();
    }
  }
}
