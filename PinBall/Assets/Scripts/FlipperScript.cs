////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: FlipperScript.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script encargado de controlar el comportamiento de los 'flippers'.
/// </summary>
public class FlipperScript : MonoBehaviour
{
    // Ángulo de posición en descanso.
    public float RestPosition = 0f;

    // Ángulo de posición presionado.
    public float PressedPosition = 45f;

    // Fuerza del golpe del impacto.
    public float HitStrength = 10000f;

    // Velocidad del flipper.
    public float FlipperDamper = 150f;

    // Nombre de la entrada
    public string InputName;

    // Referencia a la fuente de audio.
    private AudioSource _audioSource;

    // Referencia al elemento de muelle.
    private HingeJoint _hingejoint;

    // Bandera para reproducir o no el sonido del 'flipper'.
    private bool play = true;

    // Use this for initialization
    void Start()
    {
        _hingejoint = GetComponent<HingeJoint>();
        _audioSource = GetComponent<AudioSource>();
        _hingejoint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = HitStrength;
        spring.damper = FlipperDamper;


        if (Input.GetAxis(InputName) == 1)
        {
            if (play)
            {
                play = false;
                _audioSource.Play();
            }

            spring.targetPosition = PressedPosition;
        }
        else
        {
            spring.targetPosition = RestPosition;
            play = true;
        }

        _hingejoint.spring = spring;
        _hingejoint.useLimits = true;
    }
}