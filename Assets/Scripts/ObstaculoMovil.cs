﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMovil : IObstaculo {

	public float initialYPosition;
	private float timeAlive;
	private float amplitude;
	private float frecuency;

	override public void BeAffectedBy(EffectArea specialPower){
		Debug.Log ("Wololo");
	}

	private float YPosition(){
		return (Mathf.Sin (timeAlive * frecuency) - 0.5f) * amplitude;
	}

	override public void Initialize(GlobalConfig.ColorsToLines colorsToLines){
		base.Initialize (colorsToLines);
		amplitude = Random.Range (2f, 3f);
		frecuency = Random.Range (3f, 6f);
		transform.localScale += new Vector3 (Random.Range (0f, 5f), Random.Range (0f, 10f), 0f);
	}

	// Use this for initialization
	void Start () {
		timeAlive = 0;
		initialYPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;
		transform.position = new Vector3 (transform.position.x, initialYPosition + YPosition (), transform.position.z);
	}
}
