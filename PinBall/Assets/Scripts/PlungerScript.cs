////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: PlungerScript.cs
////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script encargado de lanzar la bola al empezar cada vida.
/// </summary>
public class PlungerScript : MonoBehaviour
{
    // Fuerza máxima con la que se lanza.
    public float maxPower = 100f;

    // Referencia al componente visual de barra de progreso.
    public Slider powerSlider;

    // Referencia al clip cuando está pulsado espacio.
    public AudioClip audioPressed;

    // Referencia al clip cuando se suelta el espacio.
    public AudioClip audioUp;

    // Fuerza con la que se lanza la bola.
    private float power;

    // Lista con las bolas.
    private List<Rigidbody> ballList;

    // Bandera correspondiente a si está la bola en el área de lanzamiento.
    private bool ballReady;

    // Bandera para no repetir el clip de audio.
    private bool play = true;

    // Referenciaa a la fuente de audio.
    private AudioSource _audioSource;

    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si la bola está en el área de lanzamiento, se activa el slider.
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }

        // El valor del slider es el de la variable power.
        powerSlider.value = power;

        if (ballList.Count > 0)
        {
            ballReady = true;
            // Si presionamos espacio carga la barrita
            if (Input.GetKey(KeyCode.Space))
            {
                if (power < maxPower)
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

            // Cuando lo soltamos lanzamos la bola.
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