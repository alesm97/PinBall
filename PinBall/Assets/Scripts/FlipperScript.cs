using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour {

    //Ángulo de poscion en descanso
    public float restPosition = 0f;
    //Ángulo de poscion presionado
    public float pressedPosition = 45f;
    //fuerza del golpe del impacto
    public float hitStrength = 10000f;
    // velocidad del flipper
    public float flipperDamper = 150f;
    // nombre de la entrada
    public string inputName;

    HingeJoint hingejoint;

	// Use this for initialization
	void Start () {
        hingejoint = GetComponent<HingeJoint>();
        hingejoint.useSpring = true;
	}
	
	// Update is called once per frame
	void Update () {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

		if(Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        hingejoint.spring = spring;
        hingejoint.useLimits = true;
	}
}
