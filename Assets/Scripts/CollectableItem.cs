using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour {

	private Transform tBody;

	public float speedBonus = 0f;
	public float jumpForceBonus = 0f;
	public int lifeBonus = 0;
	public int pointsBonus = 0;
	public String text;
	private BonusText bonusMessager;

	private PlayerController2 player;
	private GameObject playerObject;

	// Use this for initialization
	void Start () {
		tBody = GetComponent<Transform> ();
		playerObject = GameObject.FindWithTag ("Player");
		player = playerObject.GetComponent<PlayerController2> ();
		bonusMessager = GameObject.FindWithTag ("text_bonus_text").GetComponent<BonusText> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {

			if (text != null) {
				bonusMessager.showMessage (text, 2f);
			}
			player.addPoint (pointsBonus);
			player.addLife (lifeBonus);
			player.increseSpeed (speedBonus);
			player.increseJumpForce (jumpForceBonus);
			this.gameObject.SetActive (false);
		}
	}
}
