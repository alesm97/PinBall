using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    //Ángulo de poscion en descanso
    public float RestPosition = 0f;

    //Ángulo de poscion presionado
    public float PressedPosition = 45f;

    //fuerza del golpe del impacto
    public float HitStrength = 10000f;

    // velocidad del flipper
    public float FlipperDamper = 150f;

    // nombre de la entrada
    public string InputName;


    private AudioSource _audioSource;
    private HingeJoint _hingejoint;
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