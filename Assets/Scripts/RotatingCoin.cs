using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoin : MonoBehaviour {

	private Transform tBody;
	public float rotationSpeed = 100f;

	// Use this for initialization
	void Start () {
		tBody = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		tBody.Rotate (Vector3.right * Time.deltaTime * rotationSpeed);
	}
}
