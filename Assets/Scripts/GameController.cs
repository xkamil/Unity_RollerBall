﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {
	private static GameController instance;

	private GameController(){
	}

	public static GameController getInstance(){
		if (instance == null) {
			instance = new GameController ();
		}
		return instance;
	}

	public void endGame(){
		Debug.Log ("Game over!");
	}
}
