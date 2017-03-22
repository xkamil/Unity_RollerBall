using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;

	private Vector3 offset;
	private Transform tBody;

	void Start () {
		tBody = GetComponent <Transform> ();
		offset = tBody.position - player.position;

	}

	void LateUpdate () {
		tBody.position = player.position + offset;
	}
}
