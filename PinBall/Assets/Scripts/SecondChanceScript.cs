﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChanceScript : MonoBehaviour {

	// Pared que va a cerrarse para que pase la bola.
    public GameObject wall;
	// Fuerza con la que va a salir la bola disparada.
	public float power = 10f;
	// Segundos que va a tardar la pared en aparecer.
	public float time = .5f;
	// Sonido del repulsor
	private AudioSource audio;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		other.GetComponent<Rigidbody>().AddForce(power * Vector3.forward);
		audio.Play();
		Invoke("closeWall",time);
	}

	private void closeWall()
	{
		wall.SetActive(true);
	}
}
