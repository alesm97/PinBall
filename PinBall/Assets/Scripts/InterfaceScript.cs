using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{

	public Text pointsText;
	public Text lifesText;
	
	// Update is called once per frame
	void Update ()
	{
		pointsText.text = String.Format("Points: {0}", GameManager.points);
		lifesText.text = String.Format("Lifes: {0}", GameManager.lifes);
	}
}
