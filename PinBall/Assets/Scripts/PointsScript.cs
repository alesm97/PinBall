using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{

	public int points;
	
	private void OnTriggerExit(Collider other)
	{
		GameManager.points += points;
	}
}
