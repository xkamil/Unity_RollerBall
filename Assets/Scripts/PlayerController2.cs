using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController2 : MonoBehaviour {
	public float startSpeed = 4f;
	public float startJumpForce = 2f;

	private float speed = 4f;
	private float jumpForce = 2f;

	private Transform tBody;
	private Rigidbody rBody;
	private Vector3 startPosition;
	private GameController gameController;
	private Text textPoints;
	private Text textLives;
	private bool canMove = false;

	private int points;
	private int lives;

	void Start () {
		tBody = GetComponent <Transform> ();
		rBody = GetComponent <Rigidbody> ();
		startPosition = tBody.position;
		gameController = GameController.getInstance();
		textPoints = GameObject.FindWithTag ("text_points").GetComponent<Text> ();
		textLives = GameObject.FindWithTag ("text_lives").GetComponent<Text> ();

		reset();
	}

	void FixedUpdate(){
		textPoints.text = "Points: " + points.ToString ();
		textLives.text = "Lives: " + lives.ToString ();

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if(canMove){
			if (isGrounded ()) {
				rBody.AddForce (new Vector3(moveHorizontal, 0f, moveVertical) * speed);
			}
				
			if (Input.GetButton ("Jump")) {
				jump ();
			}
		}
	}

	public void addPoint(int amount){
		points += amount;
	}

	public int getPoints(){
		return points;
	}

	public void addLife(int amout){
		lives += amout;
	}

	public void increseSpeed(float amount){
		speed += amount;
	}

	public void increseJumpForce(float amount){
		jumpForce += amount;
	}

	public void removeLive(){
		lives--;

		if (lives == 0)
		{
			gameController.endGame ();

			reset ();
		}
	}

	public bool isGrounded(){
		return Physics.Raycast (tBody.position, Vector3.down, 1f);
	}

	public void jump(){
		if(isGrounded ()){
			rBody.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	public void moveToStartPosition(){
		stop ();
		tBody.position = startPosition;
	}

	public void stop(){
		rBody.velocity = Vector3.zero;
		rBody.angularVelocity = Vector3.zero;
	}

	public void allowMove(bool allow){
		this.canMove = allow;
	}

	public void reset(){
		points = 0;
		lives = 3;
		speed = startSpeed;
		jumpForce = startJumpForce;
		tBody.position = startPosition;
		stop ();
		allowMove (true);
	}
}
