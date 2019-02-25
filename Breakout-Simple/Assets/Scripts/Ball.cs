using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;
	private Rigidbody rb;
	private bool ballInPlay;

	public AudioClip brickSound;
	public AudioClip wallSound;
	public AudioClip paddleSound;


    public AudioSource audio;

	void Awake () {

		rb = GetComponent<Rigidbody>();
			
	}

	void OnCollisionEnter( Collision collision){


		if (collision.gameObject.tag == "Walls") 
		{

			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = wallSound;
			audio.Play();

			//audioSources[0].clip = wallSound;
			//audioSources[0].Play ();


			Debug.Log ("Walls");
		}

		if (collision.gameObject.tag == "Bricks")
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = brickSound;
			audio.Play();
		
			//audioSources[1].clip = brickSound;
			//audioSources[1].Play ();
			//Debug.Log ("Bricks");
		}

		if (collision.gameObject.tag == "Paddle") 
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = paddleSound;
          
          audio.Play();

			Debug.Log ("Paddle");
		}
	}



	// Update is called once per frame
	void Update () {

	
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) {
		
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		
		}

	}
}
