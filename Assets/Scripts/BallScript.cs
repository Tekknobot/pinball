using UnityEngine;

public class BallScript : MonoBehaviour {
  Vector3 initialPosition;
  public GameObject wall;
  public GameObject lightingManager;

  AudioSource audioData;

  public AudioClip ballCollision;
  public AudioClip ballRoll;

  void Start() {
    initialPosition = transform.position;
    audioData = GetComponent<AudioSource>(); 
  }

  void Update() {
    if (Input.GetKeyUp("escape")) {
      transform.position = initialPosition;
      SumScore.Reset();
    }
  }

  public void OnTriggerEnter (Collider collider)
  {
    if (collider.gameObject == wall) {
      lightingManager.GetComponent<LightingManagerScript>().StrobeFunction();
      SumScore.Reset();
    }

    if (SumScore.Score > SumScore.HighScore) {
      SumScore.SaveHighScore();
    }
  }

  public void OnCollisionEnter (Collision collision) {
    if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Flipper" || collision.gameObject.tag == "StandUp")
    {
      audioData.clip = ballCollision;
      audioData.Play(0);
    }    

    if (collision.gameObject.tag == "Floor")
    {
      audioData.clip = ballRoll;
      audioData.Play(0);
    }     
  }
}
