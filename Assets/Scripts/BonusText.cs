using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BonusText : MonoBehaviour {
	private Text textBody;
	private float showTime = 0f;

	// Use this for initialization
	void Start () {
		textBody = GetComponent<Text> ();
	}
	

	void FixedUpdate(){
		if (Time.time > showTime) {
			clearMessage ();
		}
	}

	public void showMessage(String message, float timeout){
		textBody.text = message;
		showTime = Time.time + timeout;
	}

	void clearMessage(){
		textBody.text = "";
	}
}
