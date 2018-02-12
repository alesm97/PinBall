using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

	public GameObject ball;
	public GameObject[] walls = new GameObject[2];
	public GameObject nBall;
	
	private bool play = true;
	
	private AudioSource _audioSource;
	
	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.lifes > 0)
		{
			if (ball.transform.position.y < 0)
			{
				if (play)
				{
					_audioSource.Play();
					play = false;
				}

				Destroy(ball);
				Invoke("newBall",1);
			}
			else
			{
				//todo finalizar partida
			}
		}
		
	}

	private void newBall()
	{
		//GameObject newBall = Instantiate(nBall);
		ball = Instantiate(nBall);
		ball.transform.position = new Vector3(3.2f, 0.11f, -4.2f);
		GameManager.lifes--;
		foreach (GameObject wall in walls)
		{
			wall.SetActive(false);
		}

		play = true;
	}
}
