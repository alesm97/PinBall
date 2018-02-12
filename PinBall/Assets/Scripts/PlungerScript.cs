using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour {

    public float maxPower = 100f;
    public Slider powerSlider;
    public AudioClip audioPressed;
    public AudioClip audioUp;

    private float power;
    private List<Rigidbody> ballList;
    private bool ballReady;
    private bool play = true;
    private AudioSource _audioSource;

    // Use this for initialization
	void Start () {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
	    _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }



        powerSlider.value = power;

        if(ballList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if(power < maxPower)
                {
                    power += 50 * Time.deltaTime;
                }

                if (play)
                {
                    _audioSource.clip = audioPressed;
                    _audioSource.Play();
                    play = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                play = true;
                _audioSource.clip = audioUp;
                _audioSource.Play();
                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
        else
        {
            ballReady = false;
            power = 0f;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
