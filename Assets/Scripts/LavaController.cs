using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	public PlayerController2 player;

	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {
			player.removeLive ();
			player.moveToStartPosition ();
		}
	}
		
}
